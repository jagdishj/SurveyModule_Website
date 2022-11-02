import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { ApiService } from './services/api.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
   ToastrModule.forRoot({
    timeOut: 5000,
    enableHtml: true,
    positionClass: 'toast-bottom-right'
   }) 
  ],
  providers: [ToastrService, ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
