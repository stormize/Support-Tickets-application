import { TicketService } from './../../services/ticket.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ticket-listing',
  templateUrl: './ticket-listing.component.html',
  styleUrls: ['./ticket-listing.component.scss']
})
export class TicketListingComponent implements OnInit {
  tickets;
  constructor(private ticketService:TicketService) { }

  ngOnInit(): void {
  this.ticketService.GetAllTickets().subscribe(data=>{this.tickets = data; console.log(this.tickets)});
  }
 
}
