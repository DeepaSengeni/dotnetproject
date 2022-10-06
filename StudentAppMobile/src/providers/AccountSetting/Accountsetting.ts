import { Injectable } from '@angular/core';
import { Http, RequestOptions, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';
import { config } from '../../app/config';

/*
  Generated class for the Accountsetting provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class AccountsettingProvider {

    constructor(public http: Http) {
        console.log('Hello Accountsetting Provider');
    }
  ShowpaypalEmail_IU(userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/Paypaldetails?userId=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  UpdatePaypalEmail(userid, emailid): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {userId: parseInt(userid),EmailId: emailid,}
    var link = '' + config.apiUrl + '/api/Common/Paypaldetails_Insert_Update?userId=' + postParams.userId + '&EmailId=' + postParams.EmailId+ '';
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


  GetPageList_ByUserId(userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/GetPageList_ByUserId?userid=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  LoadPaymentRequestList(userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/LoadPaymentRequestList?userId=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  
 




}
