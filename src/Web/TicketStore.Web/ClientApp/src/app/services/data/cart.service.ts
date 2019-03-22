import { Injectable } from '@angular/core';
import { StorageService } from '../storage.service';
import { CartItem } from 'src/app/domain';
import { RouterService } from '../router.service';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class CartService {
  
    private static readonly USER_CART = 'IDENTITY_CART';

    constructor(private storageService: StorageService, private routerService: RouterService) { }

    private isCartSubject = new BehaviorSubject<boolean>(this.isCart());

    public isCart$ = this.isCartSubject.asObservable();

    private isCartRemoveItemSubject = new BehaviorSubject<boolean>(false);
    public isCartRemove$ = this.isCartRemoveItemSubject.asObservable();
    
    private items: CartItem[] = null;

    public getCounOfCartElements(){
        if (!this.items) {
            this.items = this.getCart()
        }

        return this.items.reduce(function (s, a) {
            return s + a.qty;
        }, 0);
    }

    public getCart() : CartItem[]{
        if (!this.items) {
            var elementStr = this.storageService.getItem(CartService.USER_CART);
            if(!elementStr){
                this.setEmptyCart();
            } else {
                this.items = JSON.parse(elementStr);
            }
        }
        return this.items;
    }

    public addToCart(ticket : CartItem){
        this.items = this.getCart() || null;
        if(this.items.find(t => t.id == ticket.id)){
            this.items.find(t => t.id == ticket.id).qty += ticket.qty;
        }
        else{
            this.items.push(ticket);
        }

        this.setCart(this.items)
        this.isCartSubject.next(true);
    }

    public changeTicketQty(ticket : CartItem){
        if(this.items.find(t => t.id == ticket.id)){
            this.items.find(t => t.id == ticket.id).qty = ticket.qty; 
        }
        this.setCart(this.items)
        this.isCartSubject.next(true);
    }

    public removeCartItem(ticket : CartItem){
        this.items = this.items.filter(t => t.id != ticket.id)
        this.setCart(this.items)
        this.isCartSubject.next(true);
        this.isCartRemoveItemSubject.next(true)
    }

    public isCart(): boolean {
        return this.getCart() !== null;
    }

    private setCart(items : CartItem[]): void {
        this.storageService.setItem(CartService.USER_CART, items);
    }

    private setEmptyCart(){
        this.items = [];
        this.storageService.setItem(CartService.USER_CART, []);
    }
}
