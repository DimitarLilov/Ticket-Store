import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterService, TicketService } from '../../../../services/index';
import { TicketDetails, TicketEdit } from '../../../../domain/index';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-ticket-edit',
  templateUrl: './ticket-edit.component.html',
  styleUrls: ['./ticket-edit.component.css']
})
export class TicketEditComponent implements OnInit {
  ticketEditBindingModel: TicketEdit;
  id : number

  constructor(private routerService : RouterService, private route : ActivatedRoute, private ticketService: TicketService) {
    this.ticketEditBindingModel = new TicketEdit
  }

  ngOnInit() {
    this.id = Number(this.route.snapshot.params['id']);
    this.ticketService.getTicketById(this.id)
    .pipe(map((ticket : TicketDetails) => {
        console.log(ticket);
        this.ticketEditBindingModel.name = ticket.name;
        this.ticketEditBindingModel.price = ticket.price;
        this.ticketEditBindingModel.quantity = ticket.quantity;
        this.ticketEditBindingModel.eventId = ticket.event.id;
    })).subscribe();
  }

  edit() {
    this.ticketService.editTicket(this.id,this.ticketEditBindingModel).subscribe((data) => {
        this.routerService.navigateByUrl('admin/events');
    });
  }

}
