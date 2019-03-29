namespace TicketStore.Web
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using TicketStore.Common.Mapping;
    using TicketStore.Data;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Data.Repositories;
    using TicketStore.Data.Seeding;
    using TicketStore.Services.Data;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Infrastructure.Middlewares.Auth;
    using TicketStore.Web.Shared.Categories;
    using TicketStore.Web.Shared.Events;
    using TicketStore.Web.Shared.Tickets;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(EventListItem).Assembly,
                typeof(CategoryResponseModel).Assembly,
                typeof(EventDetailsResponseModel).Assembly,
                typeof(Event).Assembly,
                typeof(Category).Assembly,
                typeof(Ticket).Assembly);

            services.AddDbContext<TicketStoreDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtTokenValidation:Secret"]));

            services.Configure<TokenProviderOptions>(opts =>
            {
                opts.Audience = this.Configuration["JwtTokenValidation:Audience"];
                opts.Issuer = this.Configuration["JwtTokenValidation:Issuer"];
                opts.Path = "/api/account/login";
                opts.Expiration = TimeSpan.FromDays(15);
                opts.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            services
                .AddAuthentication()
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = true,
                        ValidIssuer = this.Configuration["JwtTokenValidation:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = this.Configuration["JwtTokenValidation:Audience"],
                        ValidateLifetime = true,
                    };
                });

            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<TicketStoreDbContext>()
                .AddUserStore<ApplicationUserStore>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Data repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Application services
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<ITicketsService, TicketsService>();

            // Identity stores
            services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var ticketStoreDbContext = serviceScope.ServiceProvider.GetRequiredService<TicketStoreDbContext>();

                if (env.IsDevelopment())
                {
                    ticketStoreDbContext.Database.Migrate();
                }

                TicketStoreDbContextSeeder.Seed(ticketStoreDbContext, serviceScope.ServiceProvider);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseJwtBearerTokens(
                        app.ApplicationServices.GetRequiredService<IOptions<TokenProviderOptions>>(),
                        PrincipalResolver);

            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private static async Task<GenericPrincipal> PrincipalResolver(HttpContext context)
        {
            var email = context.Request.Form["email"];

            var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var password = context.Request.Form["password"];

            var isValidPassword = await userManager.CheckPasswordAsync(user, password);
            if (!isValidPassword)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            var identity = new GenericIdentity(email, "Token");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim("FirstName", user.FirstName));

            return new GenericPrincipal(identity, roles.ToArray());
        }
    }
}
