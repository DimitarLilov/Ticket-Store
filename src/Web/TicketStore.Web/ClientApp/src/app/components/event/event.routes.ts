import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AllEventComponent, DetailsEventComponent } from './index';


const EVENT_ROUTES : Routes = [
    { path: '', pathMatch: 'full', component: AllEventComponent},
    { path: ':id', component: DetailsEventComponent },
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class EventRoutingModule {}