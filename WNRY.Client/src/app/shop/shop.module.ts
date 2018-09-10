import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }        from '@angular/forms';
import { SharedModule }       from '../shared/modules/shared.module';

import { routing }  from './shop.routing';
/*
import { RootComponent } from './root/root.component';
import { HomeComponent } from './home/home.component';
import { DashboardService } from './services/dashboard.service';
 */

import { ShopHomeComponent } from './shop-home/shop-home.component';
import { ProductListComponent } from './product-list/product-list.component';
import { MatGridListModule } from '@angular/material/grid-list';

import { AuthGuard } from '../auth.guard';

import {MatCardModule} from '@angular/material/card';


@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		routing,
				SharedModule,
				MatCardModule,
				MatGridListModule
	],
	declarations: [ShopHomeComponent, ProductListComponent/* RootComponent, HomeComponent, SettingsComponent */],
	exports:      [ ],
	providers:    []
})
export class ShopModule { }
