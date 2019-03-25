import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject, empty } from 'rxjs';
import { map, catchError } from 'rxjs/operators';



import { IdentityService } from './identity.service';

import { UserLogin, UserRegister } from '../domain/index';
import { RouterService } from './router.service';
import { CartService } from './data/cart.service';

@Injectable()
export class AuthService {
    public static readonly URLS: any = {
        LOGIN: 'api/account/login',
        REGISTER: 'api/account/register'
    };

    constructor(
        private httpClient: HttpClient,
        private identityService: IdentityService,
        private cartService: CartService,
        private routerService: RouterService,)
    { }

    private isAuthorizedSubject = new BehaviorSubject<boolean>(this.isAuthorized());

    public isAuthorized$ = this.isAuthorizedSubject.asObservable();

    public register(userRegister: UserRegister) {
        return this.httpClient.post(AuthService.URLS.REGISTER, userRegister).pipe(
            map(() => {
                const userLogin = new UserLogin();
                userLogin.email = userRegister.email;
                userLogin.password = userRegister.password;

                return this.login(userLogin).subscribe(
                    () => { },
                    error => error);
            }),
            catchError(err => throwError(err)));
    }

    public login(userLogin: UserLogin): Observable<any> {
        const payload = new HttpParams()
            .set('email', userLogin.email)
            .set('password', userLogin.password)
            .toString();

        const headers = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');

        return this.httpClient.post(AuthService.URLS.LOGIN, payload, { headers: headers }).pipe(
            map((data: any) => {
                this.identityService.setToken(data['access_token'], data['expires_in']);
                this.identityService.setRoles(data['roles']);
                this.identityService.setEmail(userLogin.email);
                this.identityService.setFirstName(data['name'])

                this.isAuthorizedSubject.next(true);

                this.routerService.redirectToHome();

                return empty();
            }),
            catchError(err => throwError(err)));
    }

    public logout() {
        this.identityService.removeIdentity();

        this.isAuthorizedSubject.next(false);

        this.routerService.redirectToHome();
    }

    public isAuthorized(): boolean {
        return this.identityService.getToken() !== null;
    }

    public isAdmin(): boolean {
        if(this.identityService.getRoles() == null)
        {
            return false;
        }
        else{
            return this.identityService.getRoles().includes("Administrator")
        }
    }
}
