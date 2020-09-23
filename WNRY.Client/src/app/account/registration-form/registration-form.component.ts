
import { take } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';

import { UserService } from '../../shared/services/user.service';
import { FormsHelperService } from '../../shared/services/forms.helper.service';

@Component({
	selector: 'app-registration-form',
	templateUrl: './registration-form.component.html',
	styleUrls: ['../account-module.component.scss']
})
export class RegistrationFormComponent implements OnInit {
	errors: string[];
	isRequesting: boolean;
	submitted = false;

	form: FormGroup;
	showInvalidFormMessage = false;

	constructor(fb: FormBuilder, private userService: UserService, private router: Router, private formsHelper: FormsHelperService) {
		this.form = fb.group({ // TODO: Interface
			email: new FormControl('', [Validators.required, Validators.email]),
			name: new FormControl('', [Validators.required]),
			phone: new FormControl('', [Validators.required]),
			password: new FormControl('', [Validators.required, Validators.minLength(6)])
		});
	}

	ngOnInit() { }

	getErrorMessage(formControlName: string) {
		return this.formsHelper.getErrorMessage(formControlName);
	}

	registerUser() {
		this.submitted = true;
		this.isRequesting = true;
		if (this.form.valid) {
			this.showInvalidFormMessage = false;

			let password = this.form.controls['password'].value;
			let email = this.form.controls['email'].value;
			let phone = this.form.controls['phone'].value;
			let name = this.form.controls['name'].value;

			this.userService.register(email, password, name, phone)
				.pipe(take(1))
				.subscribe(
					result => {
						if (result) {
							this.router.navigate(['/login'], { queryParams: { brandNew: true, email: email } });
						}
					},
					error => {
						if (error !== null && error !== undefined && error.error !== null && error.error !== undefined) {
							let errorObj = error.error;

							let allErrors = Object.keys(errorObj);
							if (allErrors) {
								this.errors = [];

								allErrors.forEach(element => {
									if (element === 'DuplicateUserName') {
										this.errors.push('Вече съществува потребител с този e-mail адрес')
									} else {
										this.errors.push(errorObj[element]);
									}
									console.log(this.errors)
								});
							}
						}
					}
				);
		}
		else {
			this.showInvalidFormMessage = true;
			this.formsHelper.markFormGroupTouched(this.form);
		}
	}
};
