import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient, private dataservice: DataService) { }

  get httpOptions():any{
    if(localStorage.getItem('SessionToken')){
      return {
        headers: new HttpHeaders({
          ClientId: environment.clientId
          //,SessionID: localStorage.getItem('SessionToken')
        })
      };
    } else {
      return {
        headers: new HttpHeaders({
          CLientId: environment.clientId
        })        
      };
    }
  }

  get userId(): any {
    try{
      const tempId = this.dataservice.getEncryption('UserId');
      if(tempId === ''){
        return 0;
      }
      return tempId;
    }catch(error){
      return 0;
    }
  }


  LoginCheck(parameters) {
    return this.http.post(`${environment.APIURL}postmethod?ClientMethodType=LoginCheck`,parameters, this.httpOptions);
  }



}
