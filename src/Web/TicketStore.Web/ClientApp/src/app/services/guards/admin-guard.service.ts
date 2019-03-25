
import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthService } from '../auth.service';
import { RouterService } from '../router.service';

@Injectable()
export class AdminGuard implements CanActivate, CanActivateChild {
    constructor(private routerService: RouterService, private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.checkAuth();
    }

    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.checkAuth();
    }

    checkAuth() {
        if (this.authService.isAdmin()) {
            return true;
        }

        this.routerService.redirectToHome();

        return false;
    }
}