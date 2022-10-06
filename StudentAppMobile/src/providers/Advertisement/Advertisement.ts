import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

import { config } from '../../app/config';

/*
  Generated class for the Advertisement provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class AdvertisementProvider {

  constructor(public http: Http) {
    console.log('Hello Advertisement Provider');
  }

  Upload(data, userid): Promise<any> {
    var options = {
    };
    let body = new FormData();
    body.append('image', data);
    body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Advertisement/UploadAdFile?userId=' + userid + '';
    return new Promise((resolve, reject) => {
      this.http.post(link, body, options)
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

  CreateAd(Data, cityids, hdnFilePath, userid): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = Data;
    var link = '' + config.apiUrl + '/api/Advertisement/Adcreation?cityids=' + cityids + '&hdnFilePath=' + hdnFilePath + '&UserId=' + userid + '';
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

  LoadAd(userid): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    var link = '' + config.apiUrl + '/api/Advertisement/LoadAd?userid=' + userid + '';
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

  clickonAd(AdId, Userid, BookId): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    var link = '' + config.apiUrl + '/api/Advertisement/AdClick_Update?AdId=' + AdId + '&userId=' + Userid + '&BookId=' + BookId + '';
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

  selectedcountry(id): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    var link = '' + config.apiUrl + '/api/Advertisement/selectedCountryId?CountryID=' + id + '';
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

  GetCurrentCountryCurrencyRate(UserCountryISOcode, SelectedCountryISOCode): Promise<any> {
    var link = 'http://free.currencyconverterapi.com/api/v5/convert?q=' + SelectedCountryISOCode + '_' + UserCountryISOcode + '&compact=y';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        }, error => {
        });
    });
  }

  PaymentSuccess(Email, name, userid, title, Adid, paymentid, Currency, totalammount, Payer_id, intent, state, city_Id): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
    };
    var link = '' + config.apiUrl + '/api/Advertisement/PaymentSuccess?Email=' + Email + '&name=' + name + '&userid=' + userid + '&title=' + title + '&Adid=' + Adid + '&paymentid=' + paymentid + '&Currency=' + Currency + '&totalammount=' + totalammount + '&Payer_id=' + Payer_id + '&intent=' + intent + '&state=' + state + '&city_Id=' + city_Id + '';
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

  AdBulkSmsSend_ForAd(adid, userid, heading, cityid): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    //adid,int userid,string heading, string city_Id
    var link = '' + config.apiUrl + '/api/Advertisement/AdBulkSmsSend_ForAd?adid=' + adid + '&userid=' + userid + '&heading=' + heading + '&city_Id=' + cityid + '';
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

  Paymentfail(adid, response): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {};
    //adid,int userid,string heading, string city_Id
    var link = '' + config.apiUrl + '/api/Advertisement/paymentFailure?adid=' + adid + '&response=' + response + '';
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
