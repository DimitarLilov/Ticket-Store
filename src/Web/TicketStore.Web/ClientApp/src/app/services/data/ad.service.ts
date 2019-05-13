import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ad } from '../../domain';


@Injectable()
export class AdService {
    
    public static readonly URLS: any = {
        AD: 'api/ads/'
    };

    constructor(
        private httpClient: HttpClient)
    { }

    public getAll(){
        return this.httpClient.get<Ad[]>(AdService.URLS.AD)
    }

}
