import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { config } from '../../app/config';


/*
  Generated class for the question provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class QuestionProvider {

  constructor(public http: Http) {
    console.log('Hello question Provider');
  }

  SaveQuestion(userID, pageID, data): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      userID: userID,
      pageID: pageID,
      data: data
    }
    var link = '' + config.apiUrl + '/api/Question/AddQuestion?userID=' + postParams.userID + '&pageID=' + postParams.pageID + '&data=' + postParams.data + '';
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

  GetQuestionsByPageId(id): Promise<any> {

    var link = '' + config.apiUrl + '/api/Question/Questions_LoadBy_PageId?pageID=' + id + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  GetAnswersByPageId(id): Promise<any> {

    var link = '' + config.apiUrl + '/api/Question/Answers_LoadBy_PageId?ID=' + id + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  GetReplyToAnswersByPageId(id): Promise<any> {

    var link = '' + config.apiUrl + '/api/Question/ReplyToAnswers_LoadBy_PageId?ID=' + id + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  GetPageContent_ByPageId(pageno): Promise<any> {
    var link = '' + config.apiUrl + '/api/Book/GetPageContent_ByPageId?pageid=' + pageno + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

}
