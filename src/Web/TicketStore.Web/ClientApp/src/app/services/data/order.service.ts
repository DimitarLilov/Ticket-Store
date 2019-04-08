import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class OrderService {
  
  private isActiveOrderSubject = new BehaviorSubject<boolean>(false);

  public isActiveOrder$ = this.isActiveOrderSubject.asObservable();
  
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
        this.isActiveOrderSubject.next(true);
      });
    }
}
