import { Category } from "../category/category";
import { Ticket } from "../tickets/ticket";

export class EventDetails {
    public id : number;

    public title: string;

    public location: string;

    public town: string;

    public date: string;

    public image: string;
    
    public description: string;

    public category : Category

    public tickets : Ticket[]
}
