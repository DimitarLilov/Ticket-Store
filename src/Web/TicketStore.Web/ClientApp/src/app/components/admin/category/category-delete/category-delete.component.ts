import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/domain';
import { CategoryService, RouterService } from 'src/app/services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-delete',
  templateUrl: './category-delete.component.html',
  styleUrls: ['./category-delete.component.css']
})

export class CategoryDeleteComponent implements OnInit {
    categoryDeleteBindingModel : Category
    id: string

  constructor(private categoryService : CategoryService, private routerService : RouterService, private route : ActivatedRoute) {
  }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.categoryService.getCategoryById(this.id)
      .subscribe((data) => {
        this.categoryDeleteBindingModel = data;
      })
  }

  delete() {
    this.categoryService.deleteCategory(this.id).subscribe((id) => {
      this.routerService.navigateByUrl("admin/categories")
    })
  }

}
