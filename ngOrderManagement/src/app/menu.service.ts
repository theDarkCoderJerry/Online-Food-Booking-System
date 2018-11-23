import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from  '@angular/common/http';
import { Food } from './food';
import { AppService } from './app.service';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  // Properties
  private menuUrl = "api/OnlineFood/";
  private getMenuUrl = "GetFoodMenuapi";


  // Methods
  constructor(private httpClient : HttpClient, private appService : AppService) { }

  getFoods() : Observable<Food[]> {
    return this.httpClient.get<Food[]>(this.appService.baseUrl + this.menuUrl + this.getMenuUrl);
  }

}
