import { Component, OnInit } from '@angular/core';
import { EventDetails, Category, EventEdit } from 'src/app/domain';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { EventService, RouterService, CategoryService } from 'src/app/services';
import { NgbTimeStruct, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-event-delete',
  templateUrl: './event-delete.component.html',
  styleUrls: ['./event-delete.component.css']
})
export class EventDeleteComponent implements OnInit {
  id : string;
  eventDeleteBindingModel : EventDetails;
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
        this.eventDeleteBindingModel = data;
        this.eventDeleteBindingModel.categoryId = data.category.id;
      })
  }

  delete() {   
    this.eventService.deleteEvent(this.id).subscribe(() =>{
        this.routerService.navigateByUrl('admin/events');
    });
  }

}
