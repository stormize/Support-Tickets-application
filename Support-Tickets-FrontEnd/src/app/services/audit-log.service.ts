import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuditLogService {

  constructor() { }
  GetAllAuditLogForTicket(id){
    return this._Http.get("https://localhost:44323/api/Tickets");
  }
}
