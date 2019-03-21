﻿import { AuthGuardService } from './guards/auth-guard.service';
import { AuthNoGuardService } from './guards/auth-no-guard.service';

import { AuthErrorsInterceptorService } from './http-interceptors/auth-errors-interceptor.service';
import { AuthInterceptorService } from './http-interceptors/auth-interceptor.service';

import { IdentityService } from './identity.service';
import { RouterService } from './router.service';
import { StorageService } from './storage.service';
import { WindowRefService } from './window-ref.service';
import { AuthService } from './auth.service';
import { EventService } from './data/event.service';
import { CartService } from './data/cart.service'


export * from './guards/auth-guard.service';
export * from './guards/auth-no-guard.service';

export * from './http-interceptors/auth-errors-interceptor.service';
export * from './http-interceptors/auth-interceptor.service';

export * from './auth.service';
export * from './identity.service';
export * from './router.service';
export * from './storage.service';
export * from './window-ref.service';
export * from './data/event.service';
export * from './data/cart.service';

export const APP_SERVICES = [
    AuthGuardService,
    AuthNoGuardService,

    AuthErrorsInterceptorService,
    AuthInterceptorService,

    AuthService,
    IdentityService,
    RouterService,
    StorageService,
    WindowRefService,
    EventService,
    CartService
];
