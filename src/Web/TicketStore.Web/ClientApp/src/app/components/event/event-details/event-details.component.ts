import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from 'src/app/services';
import { EventDetails } from 'src/app/domain';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EeventTicketsComponent } from '../event-tickets/event-tickets.component';

@Component({
    selector: 'app-event-details',
    templateUrl: './event-details.component.html',
    styleUrls: ['./event-details.component.css']
})

export class DetailsEventComponent implements OnInit {
    event: EventDetails;
    id : string;

  constructor(
    private eventService : EventService,
    private route : ActivatedRoute,
    private modalService: NgbModal
    ) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.eventService.getEventsById(this.id).subscribe((data) => {
      this.event = data;
    });
  }

  open(): void {
    const modalRef = this.modalService.open(EeventTicketsComponent, { size: 'lg' });
    modalRef.componentInstance.tickets = this.event.tickets;
  }
}

