import { Component, OnInit } from '@angular/core';
import {Event} from '../../../domain/index';
import { EventService } from '../../../services/data/event.service';

@Component({
    selector: 'app-event-list',
  templateUrl: './admin-event.component.html',
  styleUrls: ['./admin-event.component.css']
})

export class AdminAllEventComponent implements OnInit{
    events : Event[];

    constructor(private eventService : EventService) {}

    ngOnInit(): void {
        this.eventService.getAllEvents().subscribe((data) => {
            this.events = data;
        });
    }
}

