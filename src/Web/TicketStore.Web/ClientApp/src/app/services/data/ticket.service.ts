import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TicketDetails, TicketCreate } from 'src/app/domain/index';
import { map } from 'rxjs/operators';

@Injectable()
export class TicketService {
    public static readonly URLS: any = {
        TICKET: 'api/tickets/',
    };

    constructor(
        private httpClient: HttpClient)
    { }

    public getTicketById(id: number){
        return this.httpClient.get<TicketDetails>(TicketService.URLS.TICKET + id)
    }

    public getManyTicketsById(cart){
        const tickets : TicketDetails[] = [];
        for(let item of cart){
         this.getTicketById(item.id)
            .pipe(map((res : TicketDetails) => {
                res.customerQuantity = item.qty;
                tickets.push(res);
            })).subscribe();
          }
          return tickets;
    }

    public crateTicket(ticket: TicketCreate){
        return this.httpClient.post(TicketService.URLS.TICKET,ticket);
    }
}
