import { Component, OnInit } from '@angular/core';
import { faTicketAlt, faUsers, faCalendarAlt, faTags, faCreditCard, faAd } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'app-event-list',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit{
    faTicketAlt = faTicketAlt;
    faUsers = faUsers;
    faCalendarAlt = faCalendarAlt;
    faTags = faTags;
    faCreditCard = faCreditCard;
    faAd = faAd;
    
    constructor() {}

    ngOnInit(): void {
        
    }
}

