import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { USER_COMPONTNTS } from './index'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserRoutingModule } from './user.routes';

@NgModule({
    declarations: [
        USER_COMPONTNTS,
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        NgbModule,
    ],
    exports: [
        USER_COMPONTNTS
    ]
})

export class UserModule {}