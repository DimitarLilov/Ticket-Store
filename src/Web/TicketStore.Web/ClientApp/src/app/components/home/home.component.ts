import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services';
import { HomeEvent } from '../../domain/index';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit{
  lastThreeEvents : HomeEvent[]
  topEvent : HomeEvent

  constructor(private eventService : EventService) {}
  
  ngOnInit(): void {
      this.eventService.getLastThreeEvents().subscribe((data) => {
        this.lastThreeEvents = data;
      }) 
      this.eventService.getTopEvent().subscribe((data) => {
        let random = Math.floor(Math.random() * Math.floor(data.length))
        this.topEvent = data[random].event;
    }) 
  }
}
