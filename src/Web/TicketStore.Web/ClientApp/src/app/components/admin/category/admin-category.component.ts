import { Component, OnInit } from '@angular/core';
import {Category} from '../../../domain/index';
import { CategoryService } from 'src/app/services';

@Component({
    selector: 'app-category-list',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.css']
})

export class AdminAllCategoryComponent implements OnInit{
    categories : Category[];

    constructor(private categoryService : CategoryService) {}

    ngOnInit(): void {
        this.categoryService.getAll().subscribe((data) => {
            this.categories = data;
        });
    }
}

