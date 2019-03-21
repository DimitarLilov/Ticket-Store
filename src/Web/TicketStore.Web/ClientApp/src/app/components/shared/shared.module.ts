import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


import { SHARED_COMPONENTS } from './index';

@NgModule({
    declarations: [
        SHARED_COMPONENTS
      ],
      imports: [
        CommonModule,
        RouterModule,
        FontAwesomeModule
      ],
      exports: [
        SHARED_COMPONENTS
      ]
})

export class SharedModule { }