import { TicketDetails, User } from "../index";

export class Order{
    public id : string;
    
    public active: boolean;

    public user: User

    public ticket: TicketDetails
}