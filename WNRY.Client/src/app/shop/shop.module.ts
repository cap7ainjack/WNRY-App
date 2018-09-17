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
import { ProductGridComponent } from './product-grid/product-grid.component';
import { BuyProductDialogComponent } from './buy-product-dialog/buy-product-dialog.component';

import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button'
import { MatDialogModule } from '@angular/material/dialog'
import { MatInputModule } from '@angular/material/input'

import { AuthGuard } from '../auth.guard';

import {MatCardModule} from '@angular/material/card';


@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		routing,
				SharedModule,
				MatCardModule,
				MatGridListModule,
				MatButtonModule,
				MatDialogModule,
				MatInputModule
	],
	declarations: [ShopHomeComponent, ProductGridComponent, BuyProductDialogComponent/* RootComponent, HomeComponent, SettingsComponent */],
	exports:      [ ],
	providers:    [],
	entryComponents: [BuyProductDialogComponent]
})
export class ShopModule { }
