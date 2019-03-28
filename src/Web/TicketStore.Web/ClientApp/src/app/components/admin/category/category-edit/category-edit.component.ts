import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/domain';
import { CategoryService, RouterService } from 'src/app/services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})

export class CategoryEditComponent implements OnInit {
    categoryEditBindingModel : Category
    id: string

  constructor(private categoryService : CategoryService, private routerService : RouterService, private route : ActivatedRoute) {
    this.categoryEditBindingModel = new Category
  }

  ngOnInit() {
this.id = this.route.snapshot.params['id'];
    this.categoryService.getCategoryById(this.id)
      .subscribe((data) => {
        this.categoryEditBindingModel = data;
      })
  }

  edit() {
    this.categoryService.editCategory(this.id,this.categoryEditBindingModel).subscribe((id) => {
      this.routerService.navigateByUrl("admin/categories")
    })
  }

}
