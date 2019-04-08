import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../../services';
import { Order } from '../../../../domain';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderComponent implements OnInit {
    orders : Order[];

  constructor(private orderService : OrderService) {
  }

  ngOnInit() {
    this.orderService.getAllOrders().subscribe((orders) => {
        this.orders = orders
    });
    this.orderService.isActiveOrder$.subscribe(
      (isActiveOrder : boolean) => {
        if(isActiveOrder){
          this.orderService.getAllOrders().subscribe((orders) => {
            this.orders = orders
          });
        }
      }
    )
  }

  activate(id : string){
    this.orderService.activateOrder(id);
  }
}
