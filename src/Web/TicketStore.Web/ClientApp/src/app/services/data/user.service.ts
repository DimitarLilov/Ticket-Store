import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {

  
    public static readonly URLS: any = {
        USER: 'api/user/',
    };

    constructor(private httpClient: HttpClient)
    { }

    getAllUserTickets(): any {
        return this.httpClient.get(UserService.URLS.USER);
    }
}
