import { Component, OnInit  } from '@angular/core';


@Component({
	selector: 'shop-home',
	templateUrl: './shop-home.component.html',
	styleUrls: ['./shop-home.component.scss']
})
export class ShopHomeComponent implements OnInit  {

	productsToDisplay = [
		{ name: 'Hibiscus Flower', price: 8, img: 'https://static.wixstatic.com/media/f61af8_f1b4935e34bc45bbbc7c7e7f1d26e7ca~mv2_d_1776_1776_s_2.jpg/v1/fill/w_1040,h_840,q_85,usm_0.66_1.00_0.01/f61af8_f1b4935e34bc45bbbc7c7e7f1d26e7ca~mv2_d_1776_1776_s_2.jpg' },
		{ name: 'Chamomile Tea', price: 9, img: 'https://static.wixstatic.com/media/f61af8_cf15a1c505cf47d39071f0773d55babc~mv2_d_1776_1776_s_2.jpg/v1/fill/w_1040,h_840,q_85,usm_0.66_1.00_0.01/f61af8_cf15a1c505cf47d39071f0773d55babc~mv2_d_1776_1776_s_2.jpg' },
		{ name: 'Rosemary ', price: 11, img: 'https://static.wixstatic.com/media/f61af8_4cc4afe185164891bf60c5fda3eb8a97~mv2_d_1776_1776_s_2.jpg/v1/fill/w_1040,h_840,q_85,usm_0.66_1.00_0.01/f61af8_4cc4afe185164891bf60c5fda3eb8a97~mv2_d_1776_1776_s_2.jpg' },
		{ name: 'Raspberry Flower', price: 8, img: 'https://static.wixstatic.com/media/f61af8_c8640a46dfa04f29aa48d3ce483eb046~mv2_d_1776_1776_s_2.jpg/v1/fill/w_1040,h_840,q_85,usm_0.66_1.00_0.01/f61af8_c8640a46dfa04f29aa48d3ce483eb046~mv2_d_1776_1776_s_2.jpg' }
	]

	ngOnInit() {

	}
}
