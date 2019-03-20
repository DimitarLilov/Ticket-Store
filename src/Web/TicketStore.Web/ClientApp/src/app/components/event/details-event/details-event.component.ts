import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from 'src/app/services';
import { EventDetails } from 'src/app/domain';

@Component({
    selector: 'app-details-event',
    templateUrl: './details-event.component.html',
    styleUrls: ['./details-event.component.css']
})
export class DetailsEventComponent implements OnInit {
    event: EventDetails;
    id : string;

  constructor(
      private eventService : EventService,
      private route : ActivatedRoute,
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.eventService.getEventsById(this.id).subscribe((data) => {
            this.event = data;
        })
  }
}

