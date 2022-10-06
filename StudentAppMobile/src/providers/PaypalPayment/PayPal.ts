import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { config } from '../../app/config';
/*
  Generated class for the PayPal provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class PayPalpay {

  Client_Id: any;
  Secret_Id: any;

  constructor(public http: Http) {
    this.Client_Id = "AR1h6IUOGH0Mw3fDMiR4xZABqSXN8dzLs06PeL7jMBgpqXEda3LXc7kqO3srKeZsq89OJgHOleNWzRpa";
    this.Secret_Id = "EKRomMAvTSJULeKtjXbtH3MsoNukSyRkqSpM7lDO1LOG2hZcy_3girW9pPYMSNbZqqEyoVkt8z0RSxl9";
  }



  GetToken(): Promise<any> {
    return new Promise(function (resolve, reject) {
      var data = "grant_type=client_credentials";
      var xhr = new XMLHttpRequest();
      xhr.withCredentials = true;

      xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4)
        {
          resolve(this.responseText);
        }
       // else
       // {
      //    reject(this.responseText);
      //  }
      });
      xhr.open("POST", "https://api.sandbox.paypal.com/v1/oauth2/token");
      xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
      xhr.setRequestHeader("Authorization", "Basic QVIxaDZJVU9HSDBNdzNmRE1pUjR4WkFCcVNYTjhkekxzMDZQZUw3ak1CZ3BxWEVkYTNMWGM3a3FPM3NyS2Vac3E4OU9KZ0hPbGVOV3pScGE6RUtSb21NQXZUU0pVTGVLdGpYYnRIM01zb051a1N5UmtxU3BNN2xETzFMT0cyaFpjeV8zZ2lyVzlwUFlNU05iWnFxRXlvVmt0OHowUlN4bDk=");
      xhr.setRequestHeader("Cache-Control", "no-cache");
      xhr.setRequestHeader("Postman-Token", "e1455c42-407f-424d-93d9-1313f57bb783");
     
      xhr.send(data);
    });
  }

  getpayment(Token, totalamount,CountryISO): Promise<any> {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + Token);
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      "intent": "sale",
      "redirect_urls": {
        "return_url": "http://localhost/callback" ,
        "cancel_url": "http://localhost/&Cancel=true"
      },
      "payer": {
        "payment_method": "paypal"
      },
      "transactions": [{
        "amount": {
          "total": ""+totalamount+"",
          "currency": "" + CountryISO + ""
        }
      }]
    };
    var link = 'https://api.sandbox.paypal.com/v1/payments/payment';
    return new Promise((resolve, reject) => {
      this.http.post(link, postParams, options)
        .map(res => res.json()).toPromise()
        .then(
          data => {
            resolve(data);
          },
          err => {
            reject(err);
          });
    });
  }

  callStudentCustomApi()
  {
    var headers = new Headers();
   // headers.append('Content-Type', 'application/json');
  //  headers.append('Authorization', 'Bearer ' + Token);
    let options = new RequestOptions({ headers: headers });
    let postParams = {
    };
    var link = '' + config.apiUrl + '/api/Advertisement/PaymentWithPaypal';
    return new Promise((resolve, reject) => {
      this.http.post(link, postParams, options)
        .map(res => res.json()).toPromise()
        .then(
          data => {
            alert(JSON.stringify(data));
            resolve(data);
          },
          err => {
            alert(JSON.stringify(err));
            reject(err);
          });
    });
  }

  ExecutePayment(Token, PaymentId, PayerId): Promise<any> {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + Token);
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      payer_id: PayerId
    }
    var link = 'https://api.sandbox.paypal.com/v1/payments/payment/' + PaymentId + '/execute/';
    return new Promise((resolve, reject) => {
      this.http.post(link, postParams, options)
        .map(res => res.json()).toPromise()
        .then(
          data => {
            resolve(data);
          },
          err => {
            reject(err);
          });
    });
  }

}
