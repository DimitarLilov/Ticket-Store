import { Component } from '@angular/core';
import { CartService, TicketService } from 'src/app/services';
import { TicketDetails } from 'src/app/domain';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartComponent{
  tickets : TicketDetails[]

  constructor(private cartService : CartService,
    private ticketService : TicketService){ 
  }

  ngOnInit(): void {
    this.cartService.isCartRemove$.subscribe(
      () => {
        let cart = this.cartService.getCart();
        this.tickets = this.ticketService.getManyTicketsById(cart);
      }
    )
  }

  change(index: number){
    let ticket = this.tickets[index];
    this.cartService.changeTicketQty({ 'id':ticket.id, "qty": ticket.customerQuantity})
  }

  remove(index: number){
    let ticket = this.tickets[index];
    this.cartService.removeCartItem({'id' : ticket.id, 'qty': ticket.customerQuantity})
  }

  sumPrice(){
    return this.tickets
    .reduce((sum : number, ticket : TicketDetails) => sum += (ticket.price * ticket.customerQuantity), 0);
  };


}
