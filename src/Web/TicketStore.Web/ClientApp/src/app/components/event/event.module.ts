import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EVENT_COMPONTNTS } from './index'
import { EventRoutingModule } from './event.routes';

@NgModule({
    declarations: [
        EVENT_COMPONTNTS
    ],
    imports: [
        CommonModule,
        EventRoutingModule
    ],
    exports: [
        EVENT_COMPONTNTS
    ]
})

export class EventModule {}