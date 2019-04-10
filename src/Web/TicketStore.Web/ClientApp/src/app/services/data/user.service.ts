import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {

  
    public static readonly URLS: any = {
        USER: 'api/users/',
        USERTICKETS: 'api/users/tickets'
    };

    constructor(private httpClient: HttpClient)
    { }

    getAllUserTickets(): any {
        return this.httpClient.get(UserService.URLS.USER);
    }
}
