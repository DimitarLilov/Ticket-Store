import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class OrderService {

  
    public static readonly URLS: any = {
        ORDERS: 'api/orders/',
    };

    constructor(private httpClient: HttpClient)
    { }

    getAllOrders(): any {
        return this.httpClient.get(OrderService.URLS.ORDERS);
    }

    activateOrder(id: string) {
      return this.httpClient.post(OrderService.URLS.ORDERS + id,null).subscribe(()=>{
      });
    }
}
