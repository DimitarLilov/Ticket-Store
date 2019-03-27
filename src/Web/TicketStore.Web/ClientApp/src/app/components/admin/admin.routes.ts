import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventCreateComponent, CategoryCreateComponent, EventEditComponent, CategoryEditComponent , AdminAllEventComponent } from './index';



const EVENT_ROUTES : Routes = [
  { path: 'events', pathMatch: 'full', component: AdminAllEventComponent},
    { path: 'events/create', pathMatch: 'full', component: EventCreateComponent},
    { path: 'events/edit/:id', pathMatch: 'full', component: EventEditComponent},
    { path: 'categories/create', pathMatch: 'full', component: CategoryCreateComponent},
    { path: 'categories/edit/:id', pathMatch: 'full', component: CategoryEditComponent},
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class AdminRoutingModule {}