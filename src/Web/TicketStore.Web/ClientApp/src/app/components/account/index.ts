import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

export * from './account.component';
export * from './login/login.component';
export * from './register/register.component';

export const ACCOUNT_COMPONENTS = [
    AccountComponent,
    LoginComponent,
    RegisterComponent
];
