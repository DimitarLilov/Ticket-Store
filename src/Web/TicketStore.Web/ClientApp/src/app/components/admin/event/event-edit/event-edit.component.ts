import { Component, OnInit } from '@angular/core';
import { EventDetails, Category, EventEdit } from 'src/app/domain';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { EventService, RouterService, CategoryService } from 'src/app/services';
import { NgbTimeStruct, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css']
})
export class EventEditComponent implements OnInit {
  id : string;
  eventEditBindingModel : EventDetails;
  categories : Category[];

  faCalendar = faCalendar;
  date : NgbDate;
  time : NgbTimeStruct

  constructor(private eventService: EventService,
    private routerService : RouterService,
    private route : ActivatedRoute,
    private categoryService : CategoryService) {
  }

  ngOnInit() {
    this.categoryService.getAll().subscribe((categories) =>{
      this.categories = categories;
    });
    
    this.id = this.route.snapshot.params['id'];
    this.eventService.getEventsById(this.id)
      .subscribe((data) => {
        let date = data.date.split('T')[0].split("-");
        this.date = new NgbDate(Number(date[0]),Number(date[1]),Number(date[2]));

        let time = data.date.split('T')[1].split(":");
        this.time = {hour: Number(time[0]), minute: Number(time[1]),second: Number(time[2])}
        this.eventEditBindingModel = data;
        this.eventEditBindingModel.categoryId = data.category.id;
      })
  }

  edit() {   
    this.eventEditBindingModel.date = `${this.date.year}/${this.date.month}/${this.date.day} ${this.time.hour}:${this.time.minute}:${this.time.second}` 
    this.eventService.editEvent(this.id, this.eventEditBindingModel)
      .subscribe((data) => {
        this.routerService.navigateByUrl("/admin/events");
      })
  }

}
