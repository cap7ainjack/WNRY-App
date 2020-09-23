
import { finalize } from 'rxjs/operators';
import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';

import { Credentials } from '../../shared/models/credentials.interface';
import { UserService } from '../../shared/services/user.service';

import { FormsHelperService } from '../../shared/services/forms.helper.service';

@Component({
	selector: 'app-login-form',
	templateUrl: './login-form.component.html',
	styleUrls: ['../account-module.component.scss']
})

export class LoginFormComponent implements OnInit, OnDestroy {

	private subscription: Subscription;
	form: FormGroup;
	showInvalidFormMessage = false;

	brandNew: boolean;
	errors: string;
	isRequesting: boolean;
	submitted = false;
	credentials: Credentials = { email: '', password: '' };

	constructor(
		private fb: FormBuilder,
		private formsHelper: FormsHelperService,
		private userService: UserService,
		private router: Router,
		private activatedRoute: ActivatedRoute) {

		this.form = fb.group({ // TODO: Interface
			email: new FormControl('', [Validators.required, Validators.email]),
			password: new FormControl('', [Validators.required, Validators.minLength(6)])
		});

	}

	ngOnInit() {

		// subscribe to router event
		this.subscription = this.activatedRoute.queryParams.subscribe(
			(param: any) => {
				this.brandNew = param['brandNew'];
				this.credentials.email = param['email'];
			});
	}

	ngOnDestroy() {
		// prevent memory leak by unsubscribing
		this.subscription.unsubscribe();
	}

	login() {
		this.submitted = true;
		this.isRequesting = true;
		this.errors = '';
		if (this.form.valid) {
			let password = this.form.controls['password'].value;
			let email = this.form.controls['email'].value;

			this.userService.login(email, password).pipe(
				finalize(() => this.isRequesting = false))
				.subscribe(
					result => {
						if (result) {
							this.router.navigate(['/shop']);
						}
					},
					error => this.errors = error);
		}
	}

	getErrorMessage(formControlName: string) {
		return this.formsHelper.getErrorMessage(formControlName);
	}
}
