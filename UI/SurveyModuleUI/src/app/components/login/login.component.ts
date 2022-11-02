import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  year:any;
  loggedIn: boolean;
  form: FormGroup;
  public isIframe: boolean;
  loaded = false;
  
  constructor(private formBuilder: FormBuilder,private router:Router, private dataservice:DataService,public api: ApiService, private toaster: ToastrService) { 
    window.localStorage.removeItem('SessionToken');
    this.year = new Date();
    this.isIframe = window != window.parent && !window.opener;
    this.loggedIn = false;
    this.form = this.formBuilder.group({
      emailid: [null, [Validators.required]],
      password: [null, [Validators.required]]
      });
  }

  ngOnInit(): void {
    this.loaded = false;
  }

  login(){
    this.loaded = false;

    if(this.form.invalid){
       this.loaded = true;
       this.toaster.error('you have not filled the correct details, please correct and try again.');
       return;
    }
    console.log('login check, calling api');
    
    //Calling API for Authentication
    this.api.LoginCheck(this.form.value).subscribe((res) => {
      console.log('Received response');
      if(1){
        this.loggedIn = true;
      } else {
        this.loggedIn = false;
      }

    });
  }

}
