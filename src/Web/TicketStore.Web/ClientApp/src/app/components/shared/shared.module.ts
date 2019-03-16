import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SHARED_COMPONENT } from './index';

@NgModule({
    declarations: [
        SHARED_COMPONENT
      ],
      imports: [
        CommonModule,
        RouterModule
      ],
      exports: [
        SHARED_COMPONENT
      ]
})

export class SharedModule { }