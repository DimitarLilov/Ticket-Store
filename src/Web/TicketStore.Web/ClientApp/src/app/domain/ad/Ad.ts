import { Event } from "../event/event";

export class Ad{
    public id: number;

    public event : Event;

    public type : string;

    public active: boolean;

    public startDate : string;

    public endDate : string;
}