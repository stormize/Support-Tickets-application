import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-audit-log',
  templateUrl: './audit-log.component.html',
  styleUrls: ['./audit-log.component.scss']
})
export class AuditLogComponent implements OnInit {
@Input() data;
  constructor() { }

  ngOnInit(): void {
  }

}
