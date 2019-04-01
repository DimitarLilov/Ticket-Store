import { Component ,OnInit } from '@angular/core';
import { AuthService, IdentityService, CartService, CategoryService } from '../../../services';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { Category } from '../../../domain';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public categories : Category[];
  public isAdmin : boolean = false;
  public isUserAuthorized: boolean = false;
  public userEmail: string = null;
  public firstName: string = null;

  faShoppingCart = faShoppingCart;
  cartItems = 0;
  isExpanded = false;
  dropdownLi : string = "nav-item dropdown";
  dropdownMenu : string = "dropdown-menu";

  constructor(private authService: AuthService,
    private identityService: IdentityService,
    private cartService: CartService,
    private categoryService: CategoryService) {
}

public logout(): void {
    this.authService.logout();
}

collapse() {
  this.isExpanded = false;
}

toggle() {
  this.isExpanded = !this.isExpanded;
}

expand() {
  this.dropdownLi.endsWith('show') 
  ? this.dropdownLi = "nav-item dropdown" 
  : this.dropdownLi = "nav-item dropdown show";

  this.dropdownMenu.endsWith('show')
  ? this.dropdownMenu = "dropdown-menu"
  : this.dropdownMenu = "dropdown-menu show";
}

ngOnInit(): void {
  this.categoryService.getAll().subscribe((categories) => {
    this.categories = categories;
  });

  this.isAdmin = this.authService.isAdmin();
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
