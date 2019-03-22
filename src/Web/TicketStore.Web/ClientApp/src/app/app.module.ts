import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app.routes.modul';
import  {NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from './components/shared/shared.module';

import { APP_SERVICES, AuthInterceptorService, AuthErrorsInterceptorService } from './services';
import { MultiplyPipe } from './pipes/multiply.pipe';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { EventModule } from './components/event/event.module';
import { CartComponent } from './components/cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CartComponent,
    MultiplyPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    SharedModule,
    AppRoutingModule,
    FormsModule,
    NgbModule ,
    EventModule   
  ],
  
  providers: [
    APP_SERVICES,
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: AuthErrorsInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
