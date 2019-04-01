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

    constructor(private categoryService : CategoryService, private route : ActivatedRoute) {}

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.id = params['id'];
            this.categoryService.getCategoryDetailsById(this.id).subscribe((category) => {
                this.category = category;
            });
        });    
    }
}

