import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CartComponent,  } from './components/cart/cart.component';
import { AdminGuard } from './services/guards/admin-guard.service';
import { CartCheckoutComponent } from './components/cart/cart-checkout/cart-checkout.component';

export const APP_ROUTES: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'account', loadChildren: './components/account/account.module#AccountModule' },
  { path: 'events', loadChildren: './components/event/event.module#EventModule' },
  { path: 'categories', loadChildren: './components/category/category.module#CategoryModule' },
  { path: 'cart', component: CartComponent, pathMatch: 'full'},
  { path: 'cart/checkout', component: CartCheckoutComponent},
  { path: 'admin',canActivate: [ AdminGuard ], loadChildren: './components/admin/admin.module#AdminModule'}
];

@NgModule({
    imports: [RouterModule.forRoot(APP_ROUTES)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
