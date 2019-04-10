import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserTicketsComponent } from './index';


const EVENT_ROUTES : Routes = [
    { path: 'tickets', component: UserTicketsComponent}
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class UserRoutingModule {}