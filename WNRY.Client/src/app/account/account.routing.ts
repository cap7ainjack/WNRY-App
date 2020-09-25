import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { RegistrationFormComponent }    from './registration-form/registration-form.component';
import { LoginFormComponent }    from './login-form/login-form.component';
import { UserProfileComponent } from './user-profile/user-profile-main/user-profile.component';
// import { FacebookLoginComponent }    from './facebook-login/facebook-login.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  { path: 'register', component: RegistrationFormComponent},
  { path: 'login', component: LoginFormComponent},
  { path: 'profile', component: UserProfileComponent}
  // { path: 'facebook-login', component: FacebookLoginComponent}
]);