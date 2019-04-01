import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoryListComponent } from './index';


const EVENT_ROUTES : Routes = [
    { path: ':id', component: CategoryListComponent },
  ]

@NgModule({
    imports: [RouterModule.forChild(EVENT_ROUTES)],
    exports: [RouterModule]
})

export class CategoryRoutingModule {}