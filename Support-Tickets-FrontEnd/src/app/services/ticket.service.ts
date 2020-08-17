import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private _Http:HttpClient) { }

  GetAllTickets(){
    return this._Http.get("https://localhost:44323/api/Tickets");
  }
  
}
