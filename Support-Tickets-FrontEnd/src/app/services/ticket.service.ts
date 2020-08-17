import { Ticket } from './../_models/ticket';
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
  GetTicketById(id){
    return this._Http.get("https://localhost:44323/api/Tickets/"+id);
  }
  UpdateTicket(id,Ticket){
    return this._Http.put("https://localhost:44323/api/Tickets/"+id,Ticket);
  }
  
}
