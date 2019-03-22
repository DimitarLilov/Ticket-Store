import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CartComponent } from './components/cart/cart.component';



export const APP_ROUTES: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'account', loadChildren: './components/account/account.module#AccountModule' },
  { path: 'events', loadChildren: './components/event/event.module#EventModule' },
  { path: 'cart', component: CartComponent, pathMatch: 'full'}
];

@NgModule({
    imports: [RouterModule.forRoot(APP_ROUTES)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
