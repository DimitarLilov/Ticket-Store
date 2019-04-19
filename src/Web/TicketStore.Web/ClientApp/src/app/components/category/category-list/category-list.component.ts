import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../../services';
import { CategoryDetails } from '../../../domain';


@Component({
    selector: 'app-category-list',
    templateUrl: './category-list.component.html',
    styleUrls: ['./category-list.component.css']
})

export class CategoryListComponent implements OnInit{
    id: string;
    category : CategoryDetails;
    page = 1;
    limit = 6;

    constructor(private categoryService : CategoryService, private route : ActivatedRoute) {}

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.id = params['id'];
            this.categoryService.getCategoryDetailsPage(this.id, this.page, this.limit).subscribe((category) => {
                this.category = category;
            });
        });    
    }

    getPage(page) {
        this.categoryService.getCategoryDetailsPage(this.id, page, this.limit).subscribe((data) => {
            this.category = data;
        });
    }
}

