import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  baseUrl = "http://localhost:49733/";

  constructor() { }
}
