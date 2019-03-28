import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventCreateComponent, 
  CategoryCreateComponent, 
  EventEditComponent, 
  CategoryEditComponent , 
  AdminAllEventComponent, 
  AdminComponent,
  AdminAllCategoryComponent } from './index';




const EVENT_ROUTES : Routes = [
  { path: '', pathMatch: 'full', component: AdminComponent},
  { path: 'events', pathMatch: 'full', component: AdminAllEventComponent},
  { path: 'events/create', pathMatch: 'full', component: EventCreateComponent},
  { path: 'events/edit/:id', pathMatch: 'full', component: EventEditComponent},
  { path: 'categories', pathMatch: 'full', component: AdminAllCategoryComponent},
  { path: 'categories/create', pathMatch: 'full', component: CategoryCreateComponent},
  { path: 'categories/edit/:id', pathMatch: 'full', component: CategoryEditComponent},
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class AdminRoutingModule {}