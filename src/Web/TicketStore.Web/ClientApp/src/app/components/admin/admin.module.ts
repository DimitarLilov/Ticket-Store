import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ADMIN_COMPONTNTS } from './index'
import { AdminRoutingModule } from './admin.routes';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
    declarations: [
        ADMIN_COMPONTNTS,
    ],
    imports: [
        FormsModule,
        CommonModule,
        NgbModule,
        AdminRoutingModule,
        FontAwesomeModule
    ],
    exports: [
        ADMIN_COMPONTNTS
    ]
})

export class AdminModule {}