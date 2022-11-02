import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private encryptionKey = 'Servey-module-encrypt-lock';
  constructor() { }

  public setEncryption(key: string, value: string){
    const conversionEncryptOutput = CryptoJS.AES.encrypt(value.toString(), this.encryptionKey).toString();
    localStorage.setItem(key,conversionEncryptOutput);
  }

  public getEncryption(key: string){
    try{
      const encryptText = localStorage.getItem(key) as string;
      return CryptoJS.AES.decrypt(encryptText,this.encryptionKey).toString(CryptoJS.enc.Utf8);
    }catch{
      return '';
    }
  }
}
