import { AuditLogService } from './../../services/audit-log.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-audit-log-listing',
  templateUrl: './audit-log-listing.component.html',
  styleUrls: ['./audit-log-listing.component.scss']
})
export class AuditLogListingComponent implements OnInit {
  auditLogs;
  ticketId;
  constructor(private auditLogService:AuditLogService,private route: ActivatedRoute) {
    this.route.queryParamMap.subscribe(queryParams => {
      this.ticketId =  queryParams.get("id");
      console.log(this.ticketId);
     })
   }

  ngOnInit(): void {
    this.auditLogService.GetAllAuditLogForTicket(this.ticketId).subscribe(data=>{
     this.auditLogs = data;
     console.log(data);
    })
  }

}
