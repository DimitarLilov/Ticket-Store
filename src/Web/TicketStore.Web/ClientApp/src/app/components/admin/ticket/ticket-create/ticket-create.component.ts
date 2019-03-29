import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterService, TicketService } from '../../../../services/index';
import { TicketCreate } from '../../../../domain/index';


@Component({
  selector: 'app-ticket-create',
  templateUrl: './ticket-create.component.html',
  styleUrls: ['./ticket-create.component.css']
})
export class TicketCreateComponent implements OnInit {
  ticketCreateBindingModel: TicketCreate;
  eventId : string

  constructor(private routerService : RouterService, private route : ActivatedRoute, private ticketService: TicketService) {
      this.ticketCreateBindingModel = new TicketCreate;
  }

  ngOnInit() {
    
  }

  create() {
    this.eventId = this.route.snapshot.params['id'];
    this.ticketCreateBindingModel.eventId = this.eventId;
    this.ticketService.crateTicket(this.ticketCreateBindingModel).subscribe((data) => {
        this.routerService.navigateByUrl(`/admin/events/${this.eventId}/tickets`);
    });
  }

}
