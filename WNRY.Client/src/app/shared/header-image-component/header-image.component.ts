import { Component, OnInit, Input } from '@angular/core';

@Component({
	selector: 'header-image',
	templateUrl: './header-image.component.html',
	styleUrls: ['./header-image.component.scss']
})

export class HeaderImageComponent implements OnInit {
	@Input('imageSrc') imageSrc: any;

	constructor() {
	}

	ngOnInit() {

	}

}
