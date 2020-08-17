import { EditTicketComponent } from './features/edit-ticket/edit-ticket.component';
import { TicketListingComponent } from './features/ticket-listing/ticket-listing.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component:TicketListingComponent},
  {path : 'ticket' , component:EditTicketComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
