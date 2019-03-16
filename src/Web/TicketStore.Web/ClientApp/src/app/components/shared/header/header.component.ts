import { Component ,OnInit } from '@angular/core';
import { AuthService, IdentityService } from '../../../services';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private authService: AuthService, private identityService: IdentityService) {
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
}


}
