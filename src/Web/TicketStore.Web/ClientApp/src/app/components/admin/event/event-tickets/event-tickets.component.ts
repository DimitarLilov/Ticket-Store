import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventDetails, Ticket } from '../../../../domain/index';
import { EventService, RouterService } from '../../../../services';


@Component({
  selector: 'app-event-tickets',
  templateUrl: './event-tickets.component.html',
  styleUrls: ['./event-tickets.component.css']
})
export class EventTicketsComponent implements OnInit {
    eventId: string;
    event : EventDetails;

  constructor(private eventService : EventService, private routerService : RouterService,
    private route : ActivatedRoute,) {
  }

  ngOnInit() {
    this.eventId = this.route.snapshot.params['id'];
    this.eventService.getEventsById(this.eventId).subscribe((data) => {
        this.event = data;
    })

  }
}
