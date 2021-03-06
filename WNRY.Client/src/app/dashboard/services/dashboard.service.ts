import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { HomeDetails } from '../models/home.details.interface';
import { ConfigService } from '../../shared/utils/config.service';

import {BaseService} from '../../shared/services/base.service';

import { Observable } from 'rxjs';


@Injectable()

export class DashboardService extends BaseService {

	baseUrl = '';

	constructor(private http: HttpClient, private configService: ConfigService) {
		super();
		this.baseUrl = configService.getApiURI();
		}

	getHomeDetails(): Observable<any> {
		let authToken = localStorage.getItem('auth_token');
		console.log(authToken);
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': `Bearer ${authToken}`
			})
		};

		return this.http.get(this.baseUrl + '/dashboard/home', httpOptions);
	}
}
