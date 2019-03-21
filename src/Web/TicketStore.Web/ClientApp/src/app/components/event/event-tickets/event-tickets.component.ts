import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Ticket } from 'src/app/domain/tickets/ticket';
import { CartService } from 'src/app/services';

@Component({
  selector: 'app-event-tickets',
  templateUrl: './event-tickets.component.html',
  styleUrls: ['./event-tickets.component.css']
})

export class EeventTicketsComponent {
  @Input() 
  tickets: Ticket[];
  quantity : number = 1;

  constructor(public activeModal: NgbActiveModal,private cartService : CartService,) {
  }

  getTickets(index: number){
    this.cartService.addToCart(this.tickets[index], this.quantity)
    this.activeModal.dismiss('Cross click')
  }
}
