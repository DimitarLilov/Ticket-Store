import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryCreate, Category, CategoryDetails } from '../../domain';


@Injectable()
export class CategoryService {
    
    public static readonly URLS: any = {
        CATEGORY: 'api/categories/'
    };

    constructor(
        private httpClient: HttpClient)
    { }

    public getAll(){
        return this.httpClient.get<Category[]>(CategoryService.URLS.CATEGORY)
    }

    public createCategory(body : CategoryCreate){
        return this.httpClient.post(CategoryService.URLS.CATEGORY,body)
    }
    
    public getCategoryById(id: string){
        return this.httpClient.get<Category>(CategoryService.URLS.CATEGORY + id);
    }

    public editCategory(id:string, body: Category){
        return this.httpClient.put(CategoryService.URLS.CATEGORY + id,body)
    }

    public deleteCategory(id:string){
        return this.httpClient.delete(CategoryService.URLS.CATEGORY + id);
    }

    public getCategoryDetailsById(id: string){
        return this.httpClient.get<CategoryDetails>(CategoryService.URLS.CATEGORY + id);
    }

    public getCategoryDetailsPage(id: string, page: number, limit:number){
        return this.httpClient.get<CategoryDetails>(CategoryService.URLS.CATEGORY  + id + `?page=${page}&limit=${limit}`)
    }
}
