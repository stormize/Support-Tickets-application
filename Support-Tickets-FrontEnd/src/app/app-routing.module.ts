import { AuditLogListingComponent } from './features/audit-log-listing/audit-log-listing.component';
import { AuditLogComponent } from './features/audit-log/audit-log.component';
import { EditTicketComponent } from './features/edit-ticket/edit-ticket.component';
import { TicketListingComponent } from './features/ticket-listing/ticket-listing.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component:TicketListingComponent},
  {path : 'ticket' , component:EditTicketComponent},
  {path: 'auditlog', component:AuditLogListingComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
