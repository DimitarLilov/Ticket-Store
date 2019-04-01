import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CATEGORY_COMPONTNTS } from './index'
import { CategoryRoutingModule } from './category.routes';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        CATEGORY_COMPONTNTS,
    ],
    imports: [
        CommonModule,
        CategoryRoutingModule,
        NgbModule,
    ],
    exports: [
        CATEGORY_COMPONTNTS
    ]
})

export class CategoryModule {}