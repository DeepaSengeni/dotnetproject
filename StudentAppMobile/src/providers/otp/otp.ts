import { Component, Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/toPromise';

import { config } from '../../app/config';;

/*
  Generated class for the otp provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class OTPProvider {

    constructor(public http: Http) {
      console.log('Hello otp Provider');
      console.log('otp--------');
    }

  SendOTP(mobileNumber): Promise<any> {   
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      mobileNumber: mobileNumber,
      messageBody:"Verification",
    }
    var link = '' + config.apiUrl + '/api/Authentication/SendOTP?mobileNumber=' + mobileNumber + '&messageBody=Verification';
    return new Promise((resolve, reject) => {      
      this.http.post(link, postParams, options)
        .map(res => res.json()).toPromise()//convert to promise
        .then(//call then instead of subscribe to form the promise chain.
          data => {
            resolve(data);
          },
          err => {
            reject(err);
          });
    });
  }

  VerifyOTP(otp): Promise<any> {
    console.log(otp);
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      OTP: otp
    }
    var link = '' + config.apiUrl + '/api/Authentication/VerifyPhone?OTP=' + otp + '';
    return new Promise((resolve, reject) => {
      this.http.post(link, postParams, options)
        .map(res => res.json()).toPromise()//convert to promise
        .then(//call then instead of subscribe to form the promise chain.
          data => {
            resolve(data);
          },
          err => {
            reject(err);
          });
    });
  }

}
