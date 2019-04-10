import { Component, OnInit } from '@angular/core';
import { UserTickets } from '../../../domain';
import { UserService } from '../../../services';

@Component({
  selector: 'app-user-tickets',
  templateUrl: './user-tickets.component.html',
  styleUrls: ['./user-tickets.component.css']
})

export class UserTicketsComponent implements OnInit{
    userTickets: UserTickets
    constructor(private userService: UserService) {}

    ngOnInit(): void {
        this.userService.getAllUserTickets().subscribe((userTickets) => {
            this.userTickets = userTickets;
        })
    }
}
