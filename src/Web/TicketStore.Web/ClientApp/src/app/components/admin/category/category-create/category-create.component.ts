import { Component, OnInit } from '@angular/core';
import { CategoryCreate } from 'src/app/domain';
import { CategoryService, RouterService } from 'src/app/services';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})

export class CategoryCreateComponent implements OnInit {
    categoryCreateBindingModel : CategoryCreate
  constructor(private categoryService : CategoryService, private routerService : RouterService) {
    this.categoryCreateBindingModel = new CategoryCreate
  }

  ngOnInit() {

  }

  create() {
    this.categoryService.createCategory(this.categoryCreateBindingModel).subscribe((id) => {
      this.routerService.navigateByUrl("admin/categories")
    })
  }

}
