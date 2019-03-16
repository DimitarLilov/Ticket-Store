import { Component } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthService } from '../../../services/index';
import { UserRegister } from '../../../domain/index';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(private authService: AuthService){ }

  public userRegister: UserRegister = new UserRegister();
  public errorMessage: string = null;

  public register(): void {
      this.authService.register(this.userRegister).subscribe(
          () => { },
          (error: HttpErrorResponse) => this.errorMessage = error.error || 'Invalid registration.');
  }
}
