import { Component, Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { config } from '../../app/config';

/*
  Generated class for the UsersInfo provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class UsersInfoProvider {

    constructor(public http: Http) {
        console.log('Hello UsersInfo Provider');
    }

  GetUserInfo(id): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/UserProfile?id=' + id + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  PaypalEmail(userid): Promise<any> {

    var link = '' + config.apiUrl + '/api/Common/Paypaldetails?userid=' + userid + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  Invitation_FriendRequest_Notification_List_IsRead_Update(userid,status, type): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      Id: userid,
      status: status,
      type: type
    }
    var link = '' + config.apiUrl + '/api/Invitation/InvitationList_UpdateStatus?Id=' + postParams.Id + '&status=' + postParams.status + '&type=' + postParams.type + '';
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
