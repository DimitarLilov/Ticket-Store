import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterService, TicketService } from '../../../../services/index';
import { TicketDetails } from '../../../../domain/index';


@Component({
  selector: 'app-ticket-delete',
  templateUrl: './ticket-delete.component.html',
  styleUrls: ['./ticket-delete.component.css']
})
export class TicketDeleteComponent implements OnInit {
  ticketDeleteBindingModel: TicketDetails;
  id : number

  constructor(private routerService : RouterService, private route : ActivatedRoute, private ticketService: TicketService) {
    this.ticketDeleteBindingModel = new TicketDetails
  }

  ngOnInit() {
    this.id = Number(this.route.snapshot.params['id']);
    this.ticketService.getTicketById(this.id).subscribe((ticket) => {
        this.ticketDeleteBindingModel = ticket;
    });
  }

  delete() {
    this.ticketService.deleteTicket(this.id).subscribe((data) => {
        this.routerService.navigateByUrl(`/admin/events/${this.ticketDeleteBindingModel.event.id}/tickets`);
    });
  }

}
