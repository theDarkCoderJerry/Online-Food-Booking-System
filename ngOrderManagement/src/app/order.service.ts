import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './food';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppService } from './app.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  // Properties
  private ordersUrl = "api/OrdersApi/";
  private placeOrderUrl = "Post";
  private getOrderHistoryUrl = "GetOrders";

  // Methods
  constructor(private httpClient : HttpClient, private appService : AppService) { }

  placeOrder(order : Order) : Observable<Order> {
    const headers = new HttpHeaders({'Content-Type' : 'application/json'});
    return this.httpClient.post<Order>(this.appService.baseUrl + this.ordersUrl +this.placeOrderUrl, order,{headers : headers} );
  }

  getOrderHistory():Observable<Order[]>{
    return this.httpClient.get<Order[]>(this.appService.baseUrl + this.ordersUrl + this.getOrderHistoryUrl);
  }


}
