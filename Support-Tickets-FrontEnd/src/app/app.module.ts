import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import { FooterComponent } from './core/footer/footer.component';
import { TicketComponent } from './features/ticket/ticket.component';
import { TicketListingComponent } from './features/ticket-listing/ticket-listing.component';
import { EditTicketComponent } from './features/edit-ticket/edit-ticket.component';
import {FormsModule ,ReactiveFormsModule  } from '@angular/forms';
import { AuditLogComponent } from './features/audit-log/audit-log.component';
import { AuditLogListingComponent } from './features/audit-log-listing/audit-log-listing.component';
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    FooterComponent,
    TicketComponent,
    TicketListingComponent,
    EditTicketComponent,
    AuditLogComponent,
    AuditLogListingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
