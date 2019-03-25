import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventCreateComponent } from './index';
import { EventEditComponent } from './event/event-edit/event-edit.component';


const EVENT_ROUTES : Routes = [
    { path: 'events/create', pathMatch: 'full', component: EventCreateComponent},
    { path: 'events/edit/:id', pathMatch: 'full', component: EventEditComponent},
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class AdminRoutingModule {}