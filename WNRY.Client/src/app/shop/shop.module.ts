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
import { MatIconModule } from '@angular/material/icon';

import { AuthGuard } from '../auth.guard';

import {MatCardModule} from '@angular/material/card';

import { LayoutModule } from '@angular/cdk/layout';
import { CartComponent } from './shopping-cart/shopping-card.component';

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
				MatInputModule,
				MatIconModule,
				LayoutModule
	],
	declarations: [
		ShopHomeComponent,
		ProductGridComponent,
		BuyProductDialogComponent,
		CartComponent
		/* RootComponent, HomeComponent, SettingsComponent */
	],
	exports:      [ ],
	providers:    [],
	entryComponents: [BuyProductDialogComponent]
})
export class ShopModule { }
