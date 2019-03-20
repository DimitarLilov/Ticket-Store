import { Component, OnInit } from '@angular/core';
import {Event} from '../../../domain/index';
import { EventService } from '../../../services/data/event.service';

@Component({
    selector: 'app-all-event',
  templateUrl: './all-event.component.html',
  styleUrls: ['./all-event.component.css']
})

export class AllEventComponent implements OnInit{
    events : Event[]

    constructor(private eventService : EventService) {}
    ngOnInit(): void {
        this.eventService.getAllEvents().subscribe((data) => {
            this.events = data;
        }) 
        
    }
}

