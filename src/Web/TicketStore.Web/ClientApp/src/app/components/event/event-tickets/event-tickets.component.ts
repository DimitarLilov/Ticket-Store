import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Ticket } from 'src/app/domain/tickets/ticket';
import { CartService } from 'src/app/services';
import { CartItem } from 'src/app/domain';

@Component({
  selector: 'app-event-tickets',
  templateUrl: './event-tickets.component.html',
  styleUrls: ['./event-tickets.component.css']
})

export class EeventTicketsComponent {
  @Input() 
  tickets: Ticket[];
  quantity : number = 1;

  constructor(public activeModal: NgbActiveModal, private cartService : CartService) {
  }

  getTickets(index: number): void{
    this.cartService.addToCart({'id': this.tickets[index].id, 'qty' : this.quantity});
    this.activeModal.dismiss('Cross click');
  }
}
