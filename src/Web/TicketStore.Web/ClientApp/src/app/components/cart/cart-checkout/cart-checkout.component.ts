import { Component } from '@angular/core';
import { CartService, TicketService } from 'src/app/services';
import { CartTicketDetails } from '../../../domain/index';

@Component({
  selector: 'app-cart-checkout',
  templateUrl: './cart-checkout.component.html',
  styleUrls: ['./cart-checkout.component.css']
})

export class CartCheckoutComponent{
  tickets : CartTicketDetails[]

  constructor(private cartService : CartService,
    private ticketService : TicketService){ 
  }

  ngOnInit(): void {
    this.cartService.currentTickets.subscribe(tickets => this.tickets = tickets);
  }

  counter(i: number) {
    return new Array(i);
  }
  sumPrice() :number{
    return this.tickets
    .reduce((sum : number, ticket : CartTicketDetails) => sum += (ticket.price * ticket.customerQuantity), 0);
  };

  continueCheckout(){
    for(let ticket of this.tickets){
      for(let i = 0; i < ticket.customerQuantity; i++){
        this.ticketService.buyTicket(ticket).subscribe();
      }
    }
  }
}
