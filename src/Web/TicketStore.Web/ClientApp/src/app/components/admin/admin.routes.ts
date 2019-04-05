import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { 
  AdminComponent,
  AdminAllEventComponent, 
  EventCreateComponent, 
  EventEditComponent, 
  EventDeleteComponent,
  EventTicketsComponent,
  AdminAllCategoryComponent,
  CategoryCreateComponent, 
  CategoryEditComponent , 
  CategoryDeleteComponent,
  TicketCreateComponent,
  TicketEditComponent,
  TicketDeleteComponent,
  OrderComponent
} from './index';




const EVENT_ROUTES : Routes = [
  { path: '', pathMatch: 'full', component: AdminComponent},
  { path: 'events', pathMatch: 'full', component: AdminAllEventComponent},
  { path: 'events/create', pathMatch: 'full', component: EventCreateComponent},
  { path: 'events/edit/:id', pathMatch: 'full', component: EventEditComponent},
  { path: 'events/delete/:id', pathMatch: 'full', component: EventDeleteComponent},
  { path: 'events/:id/tickets', pathMatch: 'full', component: EventTicketsComponent},
  { path: 'events/:id/create/ticket', pathMatch: 'full', component: TicketCreateComponent},
  { path: 'categories', pathMatch: 'full', component: AdminAllCategoryComponent},
  { path: 'categories/create', pathMatch: 'full', component: CategoryCreateComponent},
  { path: 'categories/edit/:id', pathMatch: 'full', component: CategoryEditComponent},
  { path: 'categories/delete/:id', pathMatch: 'full', component: CategoryDeleteComponent},
  { path: 'tickets/edit/:id', pathMatch: 'full', component: TicketEditComponent},
  { path: 'tickets/delete/:id', pathMatch: 'full', component: TicketDeleteComponent},
  { path: 'orders', pathMatch: 'full', component: OrderComponent},
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class AdminRoutingModule {}