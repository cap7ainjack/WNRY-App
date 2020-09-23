import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/modules/shared.module';

import { UserService } from '../shared/services/user.service';
import { FormsHelperService } from '../shared/services/forms.helper.service';

import { EmailValidator } from '../directives/email.validator.directive';

import { routing } from './account.routing';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';

import { MatButtonModule } from '@angular/material/button'
import { MatDialogModule } from '@angular/material/dialog'
import { MatInputModule } from '@angular/material/input'
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox'
// import { FacebookLoginComponent } from './facebook-login/facebook-login.component';

@NgModule({
  imports: [
    CommonModule, FormsModule, routing, SharedModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatIconModule,
    MatTableModule,
    MatFormFieldModule,
    MatSelectModule,
    MatCheckboxModule,
  ],
  declarations: [RegistrationFormComponent, EmailValidator, LoginFormComponent, /* FacebookLoginComponent */],
  providers: [UserService, FormsHelperService]
})
export class AccountModule { }
