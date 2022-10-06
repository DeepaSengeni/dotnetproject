import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Component, Injectable } from '@angular/core';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { config } from '../../app/config';
/*
  Generated class for the book provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class BooksProvider {

  constructor(public http: Http) {
    console.log('Hello book Provider');
  }

  GetPageContent_ByPageId(pageId): Promise<any> {
    var link = '' + config.apiUrl + '/api/Book/GetPageContent_ByPageId?pageId=' + pageId+'';
   return new Promise(resolve => {
  this.http.get(link)
    .subscribe(data => {
      resolve(data.json());
    });
});
  }

  Notesbook_Pages(bookid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/Notesbook_Pages?BookId=' + bookid +'';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  uploadpic(data, filename, PageType): Promise<any> {
    var options = {
    };
    let body = new FormData();
    body.append('picture', data);
    body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Book/pageimageupload?filename=' + filename + '&PageType=' + PageType+'';
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

  Videoupload(data) {
    var options = {
    };
    let body = new FormData();
    body.append('video', data);
    body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Book/UploadVideoFile';

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

  insertpageclick(pageid,userid,action): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      PageId: pageid,
      userid: userid,
      action: action
    }
    var link = '' + config.apiUrl + '/api/Pages/pagelike?PageId=' + postParams.PageId + '&userid=' + postParams.userid + '&action=' + postParams.action + '';
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

  GetIP(): Promise<any>
  {
    var link = 'http://ipinfo.io';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  insertpageClick(PageId, userid, device): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      PageId: PageId,
      userid: userid,
      device: device
    }
    var link = '' + config.apiUrl + '/api/Pages/insertpageclick?PageId=' + postParams.PageId + '&userid=' + postParams.userid + '&device=' + postParams.device + '';
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

  PageContentByPageId(pageid): Promise<any>
  {
    var link = '' + config.apiUrl + '/api/Book/GetPageContent_ByPageId?pageid=' + pageid + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }



  

}


