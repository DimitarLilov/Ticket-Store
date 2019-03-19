namespace TicketStore.Data.Seeding
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TicketStore.Common;
    using TicketStore.Data.Models;

    public class TicketStoreDbContextSeeder
    {
        public static void Seed(TicketStoreDbContext ticketStoreDbContext, IServiceProvider serviceProvider)
        {
            if (ticketStoreDbContext == null)
            {
                throw new ArgumentNullException(nameof(ticketStoreDbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            Seed(ticketStoreDbContext, roleManager);
        }

        public static void Seed(TicketStoreDbContext ticketStoreDbContext, RoleManager<ApplicationRole> roleManager)
        {
            if (ticketStoreDbContext == null)
            {
                throw new ArgumentNullException(nameof(ticketStoreDbContext));
            }

            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            SeedRoles(roleManager);
        }

        private static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            SeedRole(GlobalConstants.AdministratorRoleName, roleManager);
        }

        private static void SeedRole(string roleName, RoleManager<ApplicationRole> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
            if (role == null)
            {
                var result = roleManager.CreateAsync(new ApplicationRole(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
