import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';

import { config } from '../../app/config';

/*
  Generated class for the common provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class CommonProvider {

    constructor(public http: Http) {
        console.log('Hello common Provider');
    }

  CheckCityAvailability(cityId, startdate, enddate): Promise<any> {
    var link = '' + config.apiUrl + '/api/Advertisement/CheckCityAvailability?cityId=' + cityId + '&startDate=' + startdate + '&endDate=' + enddate + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }


  GetCountryDetail(userid): Promise<any> {
    parseInt(userid);
    var link = '' + config.apiUrl + '/api/Common/GetCountryDetail?userid=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  updatewallet(userid): Promise<any> {
    parseInt(userid);
    var link = '' + config.apiUrl + '/api/Common/Wallet_ByuserId?userId=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  NotificationsCount(userid): Promise<any> {
    parseInt(userid);
    var link = '' + config.apiUrl + '/api/Common/NotificationList?id=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  NotificationList(userid): Promise<any> {
    parseInt(userid);
    var link = '' + config.apiUrl + '/api/Common/NotificationList1?id=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  Message_Load(userid, bookid, pageno, name): Promise<any>
  {  
    var link = '' + config.apiUrl + '/api/Pages/Message_Load?userid=' + userid + '&bookid=' + bookid + '&pageno=' + pageno + '&name=' + name+'';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  SendSMSToMobile(mobileNumbers, messageBody, messageCount) {
    var link = '' + config.apiUrl + '/api/Common/SendSMSToMobile?mobileNumbers=' + mobileNumbers + '&messageBody=' + messageBody + '&messageCount=' + messageCount + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  Invitation_FriendRequest_Notification_List_IsRead_Update(userid,type): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    var link = '' + config.apiUrl + '/api/Users/Invitation_FriendRequest_Notification_List_IsRead_Update?userid=' + userid + '&type=' + type + '';
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
  

  Setting(userid, email,password,contact): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    var link = '' + config.apiUrl + '/api/Common/Setting?userId=' + userid + '&Email=' + email + '&Password=' + password + '&contact=' + contact+'';
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
  DeleteAccount(userid): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    var link = '' + config.apiUrl + '/api/Common/DeleteAccount?userId=' + userid + '';
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
