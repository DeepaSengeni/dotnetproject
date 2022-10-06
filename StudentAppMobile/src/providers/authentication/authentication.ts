import { Component, Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { config } from '../../app/config';

@Injectable()
export class AuthenticationProvider {
 
  constructor(public http: Http) {
    console.log('Hello authentication Provider');
  }

  Login(userName, loginPassword): Promise<any> {   
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      UserName: userName,
      LoginPassword: loginPassword   
    }
    var link = '' + config.apiUrl + '/api/Authentication/Login?UserName=' + postParams.UserName + '&LoginPassword=' + postParams.LoginPassword + '';
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

  UsersLoginInfo_Insert_Update(userid): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      id: userid
    }
    var link = '' + config.apiUrl + '/api/Authentication/UsersLoginInfo_Insert_Update?id=' + postParams.id + '';
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

  logOff(userid): Promise<any>
  {
    var link = '' + config.apiUrl + '/api/Authentication/logoff?userid=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  Register(student): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });  
    let postParams = student;
    var link = '' + config.apiUrl + '/api/Authentication/SignUp';    
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

  isEmailExist(email: string): Promise<any> {
    var link = '' + config.apiUrl + '/api/Authentication/CheckEmailExist?EmailID='+email+'';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  isMobileNoExist(Mobile): Promise<any> {
    var link = '' + config.apiUrl + '/api/Authentication/CheckEmail?Mobile=' + Mobile + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  ForgotPassword(email: string): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = JSON.stringify({ Email: email });
    var link = '' + config.apiUrl + '/api/Authentication/ForgotPassword?Email=' + email + '';
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

  Editprofile(profile): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = profile;
    var link = '' + config.apiUrl + '/api/Users/UpdateUserDetail';
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
