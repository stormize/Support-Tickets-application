import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-audit-log-listing',
  templateUrl: './audit-log-listing.component.html',
  styleUrls: ['./audit-log-listing.component.scss']
})
export class AuditLogListingComponent implements OnInit {
  auditLogs;
  constructor() { }

  ngOnInit(): void {
    
  }

}
