import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EVENT_COMPONTNTS } from './index'
import { EventRoutingModule } from './event.routes';
import { EeventTicketsComponent } from './event-tickets/event-tickets.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        EVENT_COMPONTNTS,
    ],
    imports: [
        FormsModule,
        CommonModule,
        EventRoutingModule,
        NgbModule
    ],
    entryComponents: [EeventTicketsComponent],
    exports: [
        EVENT_COMPONTNTS
    ]
})

export class EventModule {}