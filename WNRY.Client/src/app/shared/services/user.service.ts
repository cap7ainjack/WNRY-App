
import {map, catchError,  take } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

import { UserRegistration } from '../models/user-registration.interface';
import { ConfigService } from '../utils/config.service';

import {BaseService} from './base.service';

import { Observable ,  BehaviorSubject } from 'rxjs/Rx';

// Add the RxJS Observable operators we need in this app.
import '../../rxjs-operators';

@Injectable()

export class UserService extends BaseService {

	baseUrl = '';

	// Observable navItem source
	private _authNavStatusSource = new BehaviorSubject<boolean>(false);
	// Observable navItem stream
	authNavStatus$ = this._authNavStatusSource.asObservable();

	private loggedIn = false;

	constructor(private http: HttpClient, private configService: ConfigService) {
		super();
		this.loggedIn = !!localStorage.getItem('auth_token');
		// ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
		// header component resulting in authed user nav links disappearing despite the fact user is still logged in
		this._authNavStatusSource.next(this.loggedIn);
		this.baseUrl = configService.getApiURI();
	}

	register(email: string, password: string, firstName: string, lastName: string, location: string): Observable<any> {
	let body = JSON.stringify({ email, password, firstName, lastName, location });
	let httpOptions = {
		headers: new HttpHeaders({
			'Content-Type':  'application/json'
		})
	}

	return this.http.post(this.baseUrl + '/accounts', body, httpOptions)
		.pipe(
		map(res => true),
		catchError(this.handleError));
	}

	login(userName, password) {
		let httpOptions = {
		headers: new HttpHeaders({
			'Content-Type':  'application/json'
		})
	}

		return this.http
			.post(
			this.baseUrl + '/auth/login',
			JSON.stringify({ userName, password }), httpOptions)
			.pipe(
			map((response: HttpResponse<any>) => {
				let result = response;
				if (result && result['auth_token']) {
					localStorage.setItem('auth_token', result['auth_token']);
				}
			this.loggedIn = true;
			this._authNavStatusSource.next(true);
			return true;
		}),
		catchError(this.handleError));
	}

	logout() {
		localStorage.removeItem('auth_token');
		this.loggedIn = false;
		this._authNavStatusSource.next(false);
	}

	isLoggedIn() {
		return this.loggedIn;
	}

	facebookLogin(accessToken: string) {
		let httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json'
			})
		}
		let body = JSON.stringify({ accessToken });
		return this.http
			.post(
			this.baseUrl + '/externalauth/facebook', body, httpOptions)
			.pipe(
			map((response: HttpResponse<any>) => {
				let result = response;
				if (result && result['auth_token']) {
					localStorage.setItem('auth_token', result['auth_token']);
				}
			this.loggedIn = true;
			this._authNavStatusSource.next(true);
			return true;
		}),
		catchError(this.handleError));
	}
}
