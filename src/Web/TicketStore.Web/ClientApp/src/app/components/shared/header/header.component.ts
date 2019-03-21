import { Component ,OnInit } from '@angular/core';
import { AuthService, IdentityService, CartService } from '../../../services';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { CartItem } from 'src/app/domain';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  faShoppingCart = faShoppingCart;
  cartItems = 0;
  constructor(private authService: AuthService,
    private identityService: IdentityService,
    private cartService: CartService) {
}

public isUserAuthorized: boolean = false;
public userEmail: string = null;
public firstName: string = null;
isExpanded = false;
public isAdmin : boolean = false;

public logout(): void {
    this.authService.logout();
}

collapse() {
  this.isExpanded = false;
}

toggle() {
  this.isExpanded = !this.isExpanded;
}


ngOnInit(): void {
  this.authService.isAuthorized$.subscribe(
    (isAuthorized: boolean) => {
        this.isUserAuthorized = isAuthorized;
        this.userEmail = isAuthorized ? this.identityService.getEmail() : null;
        this.firstName = isAuthorized ? this.identityService.getFirstName() : null;
        
    });
    this.cartService.isCart$.subscribe(
      (isCart : boolean) => {
        this.cartItems = isCart ? this.cartService.getCounOfCartElements() : 0;
      }
    )
}


}
