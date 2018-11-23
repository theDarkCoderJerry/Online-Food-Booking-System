export class Food {
    FoodId : number;
    FoodItem : string;
    Price : number;
    Quantity : number;
    
}

export class Order {
    OrderId : number;
    CustomerName : string;
    TotalPrice : number;
    Date : string;
    Foods : Food[];
    ShowOrNot : boolean;
}
