import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule, Routes } from '@angular/router';
import {FormsModule} from '@angular/forms'

import { AppComponent } from './app.component';
import { OrderComponent } from './order/order.component';

import { AppService } from './app.service';
import { MenuService } from './menu.service';
import { OrderService } from './order.service';
import { HomeComponent } from './home/home.component';
import { HistoryComponent } from './history/history.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderComponent,
    HomeComponent,
    HistoryComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path :'History' ,component : HistoryComponent},
      {path : 'Order', component : OrderComponent},
      {path : '', component : HomeComponent}
      
    ])
  ],
  providers: [AppService,MenuService,OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }

