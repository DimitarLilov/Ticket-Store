import { Component, OnInit } from '@angular/core';
import { EventList } from '../../../domain/index';
import { EventService } from '../../../services/data/event.service';

@Component({
    selector: 'app-event-list',
  templateUrl: './admin-event.component.html',
  styleUrls: ['./admin-event.component.css']
})

export class AdminAllEventComponent implements OnInit{
    events : EventList;
    page = 1;
    limit = 6;

    constructor(private eventService : EventService) {}

    ngOnInit(): void {
        this.eventService.getEventsPage(this.page, this.limit).subscribe((data) => {
            this.events = data;
        });
    }

    getPage(page) {
        this.eventService.getEventsPage(page, this.limit).subscribe((data) => {
            this.events = data;
        });
    }
}

