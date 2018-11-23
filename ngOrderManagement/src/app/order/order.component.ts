import { Component, OnInit } from '@angular/core';
import { MenuService } from '../menu.service';
import { Food, Order } from '../food';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  // Properties
  foods : Food[];

  cart : Order = {
    OrderId : 0,
    TotalPrice : 0,
    CustomerName : "",
    Foods : [],
    Date : "" ,
    ShowOrNot : false

    
  }

  showMessageDiv = false;
  message = "";

  // Methods
  constructor(private menuService : MenuService, private orderService : OrderService) { }

  ngOnInit() {
    this.menuService.getFoods().subscribe(foods => {
      this.foods = foods;
    });
  }

  addToCart(food : Food) {
    this.closeMessageDiv();
    let isFoodInCart = false;
    this.cart.Foods.forEach(foodInCart => {
      if(foodInCart.FoodId == food.FoodId) {
        foodInCart.Quantity += 1;
        isFoodInCart = true;
      }
    });
    if(!isFoodInCart) {
      food.Quantity = 1;
      this.cart.Foods.push(food);
    }
    this.calculateTotalPrice();
  }

  calculateTotalPrice() {
    let totalPrice = 0;
    this.cart.Foods.forEach(food => {
      totalPrice += food.Price * food.Quantity;
    });
    this.cart.TotalPrice = totalPrice;
  }

  addQuantity(food : Food) {
    this.cart.Foods.forEach(foodInCart => {
      if(foodInCart.FoodId == food.FoodId) {
        foodInCart.Quantity += 1;
      }
    });
    this.calculateTotalPrice();
  }
  reduceQuantity(food : Food) {
    this.cart.Foods.forEach(foodInCart => {
      if(foodInCart.FoodId == food.FoodId) {
        if(foodInCart.Quantity > 1)
        foodInCart.Quantity -= 1;
        else {
          this.removeFoodFromCart(foodInCart);
        }
      }
    });
    this.calculateTotalPrice();
  }

  removeFoodFromCart(food : Food) {
    var index = this.cart.Foods.indexOf(food);
    this.cart.Foods.splice(index, 1); 
    this.calculateTotalPrice();    
  }

  placeOrder() {
    if(this.cart.TotalPrice > 0) {
      this.openMessageDiv("Please Wait ... ");
      this.orderService.placeOrder(this.cart).subscribe(cart =>{
      this.openMessageDiv("Order Placed Successfully");
        this.cart = {
          OrderId : 0,
          TotalPrice : 0,
          CustomerName : "",
          Foods : [],
          Date : "" ,
          ShowOrNot : false
        }
      });
    } else {
      this.openMessageDiv("Please add food to your cart before proceeding !!! ");
    }
  }

  closeMessageDiv() {
    this.showMessageDiv = false;
    this.message = "";
  }
  openMessageDiv(messageString : string) {
    this.showMessageDiv = true;
    this.message = messageString;
  }

}
