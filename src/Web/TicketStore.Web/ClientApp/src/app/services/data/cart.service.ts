import { Injectable } from '@angular/core';
import { StorageService } from '../storage.service';
import { CartItem } from 'src/app/domain';
import { Ticket } from 'src/app/domain/tickets/ticket';
import { RouterService } from '../router.service';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class CartService {
  
    private static readonly USER_CART = 'IDENTITY_CART';

    constructor(private storageService: StorageService, private routerService: RouterService) { }

    private isCartSubject = new BehaviorSubject<boolean>(this.isCart());

    public isCart$ = this.isCartSubject.asObservable();
    
    private items: CartItem[] = null;

    public getCounOfCartElements(){
        if (!this.items) {
            var elementStr = this.storageService.getItem(CartService.USER_CART);
            this.items = JSON.parse(elementStr)

        }
        return this.items.length;
    }

    public setCart(item): void {
        this.items = this.getCart();

        this.items.push(item);

        this.storageService.setItem(CartService.USER_CART, this.items);
    }

    public getCart(){
        if (!this.items) {
            var elementStr = this.storageService.getItem(CartService.USER_CART);
            this.items = JSON.parse(elementStr)

        }
        return this.items;
    }

    public addToCart(tiket : Ticket, quantity : number){
        for(let i = 0; i < quantity; i++){
            this.setCart(tiket)
        }
        this.isCartSubject.next(true);
    }

    public isCart(): boolean {
        return this.getCart() !== null;
    }
}
