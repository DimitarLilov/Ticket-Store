import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Event, EventDetails, EventCreate, HomeEvent, EventEdit } from '../../domain/index';


@Injectable()
export class EventService {
    
    public static readonly URLS: any = {
        EVENTS: 'api/events/',
        GET_LAST_THREE_EVENTS: 'api/events?&orderByDecending=id&limit=3',
        GET_TOP_EVENTS: 'api/events?&orderBy=id&limit=2',
    };

    constructor(
        private httpClient: HttpClient)
    { }


    public getAllEvents() {
        return this.httpClient.get<Event[]>(EventService.URLS.EVENTS)
    }

    public getEditEventsById(id :string){
        return this.httpClient.get<EventEdit>(EventService.URLS.EVENTS + id);
    }

    public getEventsById(id: string){
        return this.httpClient.get<EventDetails>(EventService.URLS.EVENTS + id)
    }
    
    public getLastThreeEvents() {
        return this.httpClient.get<HomeEvent[]>(EventService.URLS.GET_LAST_THREE_EVENTS)
    }

    public getTopEvent()
    {
        return this.httpClient.get<HomeEvent>(EventService.URLS.GET_TOP_EVENTS)
    }

    public createEvent(body : EventCreate){
        return this.httpClient.post(EventService.URLS.EVENTS,body)
    }

    public editEvent(id: string, body: EventDetails) {
        return this.httpClient.put(EventService.URLS.EVENTS + id,body)
    }

    public deleteEvent(id: string){
        return this.httpClient.delete(EventService.URLS.EVENTS + id);
    }
}
