import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuditLogService {

  constructor(private _Http:HttpClient) { }
  GetAllAuditLogForTicket(id){
    return this._Http.get("https://localhost:44323/api/AuditLogs/auditForTicket/"+id);
  }
}
