import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Event, EventDetails } from '../../domain/index';
import { map } from 'rxjs/operators';

@Injectable()
export class EventService {
    public static readonly URLS: any = {
        GET: 'api/events/',
    };

    constructor(
        private httpClient: HttpClient)
    { }

    public getAllEvents() {
        return this.httpClient.get<Event[]>(EventService.URLS.GET)
    }

    public getEventsById(id: string){
        return this.httpClient.get<EventDetails>(EventService.URLS.GET + id)
    }
}
