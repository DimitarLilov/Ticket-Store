import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryCreate } from 'src/app/domain';


@Injectable()
export class CategoryService {
    
    public static readonly URLS: any = {
        CATEGORY: 'api/categories/'
    };

    constructor(
        private httpClient: HttpClient)
    { }

    public createCategory(body : CategoryCreate){
        return this.httpClient.post(CategoryService.URLS.CATEGORY,body)
    }
}
