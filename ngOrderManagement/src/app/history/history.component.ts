import { Component, OnInit } from '@angular/core';
import { OrderService } from '../order.service';
import { Order } from '../food';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  // Properties
  orderHistory : Order[];
  showOrNot = true ;
  // Methods
  constructor(private orderService : OrderService ) { }

  ngOnInit() {
    this.orderService.getOrderHistory().subscribe(orders => 
      {
       this.orderHistory = orders;
       this.orderHistory.forEach(order => {
         order.ShowOrNot = false;
         
       });
      });
  }
  

   displayFoodDetails(order :Order)
   {
  if(order.ShowOrNot == true)
  {
    order.ShowOrNot =false
  }
  else
  {
    order.ShowOrNot = true
    }
  }
}