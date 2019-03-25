import { Component, OnInit } from '@angular/core';
import { EventCreate } from 'src/app/domain';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { EventService, RouterService } from 'src/app/services';
import { NgbTimeStruct, NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-event-create',
  templateUrl: './event-create.component.html',
  styleUrls: ['./event-create.component.css']
})
export class EventCreateComponent implements OnInit {
  eventCreateBindingModel : EventCreate;
  faCalendar = faCalendar;
  date :  {year: number, month: number, day: number};;
  time : NgbTimeStruct

  constructor(private eventService: EventService, private routerService : RouterService) {
    this.eventCreateBindingModel = new EventCreate();
  }

  ngOnInit() {
  }

  create() {
    this.eventCreateBindingModel.eventDateTime = `${this.date.year}/${this.date.month}/${this.date.day} ${this.time.hour}:${this.time.minute}:${this.time.second}`
    this.eventService.createEvent(
        this.eventCreateBindingModel)
        .subscribe((id) =>{
            this.routerService.navigateByUrl("events/"+id);
        });
  }

}
