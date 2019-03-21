import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app.routes.modul';
import  {NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from './components/shared/shared.module';


import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { APP_SERVICES, AuthInterceptorService, AuthErrorsInterceptorService } from './services';
import { EeventTicketsComponent } from './components/event/event-tickets/event-tickets.component';
import { EventModule } from './components/event/event.module';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    SharedModule,
    AppRoutingModule,
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
