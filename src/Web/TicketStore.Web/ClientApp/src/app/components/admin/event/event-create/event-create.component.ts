import { Component, OnInit } from '@angular/core';
import { EventCreate, Category } from 'src/app/domain';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { EventService, RouterService, CategoryService } from 'src/app/services';
import { NgbTimeStruct, NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-event-create',
  templateUrl: './event-create.component.html',
  styleUrls: ['./event-create.component.css']
})
export class EventCreateComponent implements OnInit {
  eventCreateBindingModel : EventCreate;
  categories : Category[];
  faCalendar = faCalendar;
  date :  {year: number, month: number, day: number};;
  time : NgbTimeStruct

  constructor(private eventService: EventService, private routerService : RouterService, private categoryService : CategoryService) {
    this.eventCreateBindingModel = new EventCreate();
  }

  ngOnInit() {
    this.categoryService.getAll().subscribe((categories) =>{
      this.categories = categories;
    });
  }

  create() {
    // this.eventCreateBindingModel.eventDateTime = `${this.date.year}/${this.date.month}/${this.date.day} ${this.time.hour}:${this.time.minute}:${this.time.second}`
    // this.eventService.createEvent(
    //     this.eventCreateBindingModel)
    //     .subscribe((id) =>{
    //         this.routerService.navigateByUrl("events/"+id);
    //     });
  }

}
