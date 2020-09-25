
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
	selector: 'app-user-profile-info',
	templateUrl: './user-profile-info.component.html',
	styleUrls: ['../../account-module.component.scss']
})

export class UserProfileInfoComponent implements OnInit {

	constructor(
		private router: Router,
		private activatedRoute: ActivatedRoute) {

	}

	ngOnInit() {	}
}