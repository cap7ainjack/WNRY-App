
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
	selector: 'app-user-profile',
	templateUrl: './user-profile.component.html',
	styleUrls: ['../../account-module.component.scss']
})

export class UserProfileComponent implements OnInit {

	constructor(
		private router: Router,
		private activatedRoute: ActivatedRoute) {

	}

	ngOnInit() {	}
}