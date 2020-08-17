import { Ticket } from './../../_models/ticket';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl,Validators  } from '@angular/forms';
import { TicketService } from 'src/app/services/ticket.service';
import { Router, UrlTree, UrlSegmentGroup, UrlSegment, PRIMARY_OUTLET, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-edit-ticket',
  templateUrl: './edit-ticket.component.html',
  styleUrls: ['./edit-ticket.component.scss']
})
export class EditTicketComponent implements OnInit {
  ticketDataForm: FormGroup;
  ticketId;
  toastStatus:boolean = false;
  ticket:Ticket;
  constructor(private ticketService:TicketService,private route: ActivatedRoute) {
    this.route.queryParamMap.subscribe(queryParams => {
     this.ticketId =  queryParams.get("id");
    })
 
   }

  ngOnInit(): void {
   this.ticketService.GetTicketById(this.ticketId).subscribe((data:Ticket)=>{
     this.ticket = data;
     this.ticketDataForm = new FormGroup({
      Name: new FormControl(this.ticket.name,Validators.minLength(4)),
      Content: new FormControl(this.ticket.content,Validators.minLength(8)),
      Status: new FormControl(this.ticket.status),
    });
    });
  
  }
  onSubmit(): void {
   
    this.ticket.name = this.ticketDataForm.value.Name;
    this.ticket.status = this.ticketDataForm.value.Status;
    this.ticket.content = this.ticketDataForm.value.Content;
    
    this.ticketService.UpdateTicket(this.ticketId,this.ticket).subscribe(data=>{
      this.toastStatus = true;
    });
  }
}
