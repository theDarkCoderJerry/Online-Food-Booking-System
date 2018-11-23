import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { Order } from '../food';
import { OrderComponent } from '../order/order.component';

@NgModule({
  
  exports: [
    RouterModule  ]
})
export class AppRoutingModule { }

