import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { config } from '../../app/config';

/*
  Generated class for the answer provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class AnswerProvider {

    constructor(public http: Http) {
        console.log('Hello answer Provider');
    }

  SaveReply(userID, data, questionID, answerID): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      userID: userID,
      questionID: questionID,
      data: data,     
      answerID: answerID
    }
    var link = '' + config.apiUrl + '/api/Answer/InsertAnswer?userID=' + postParams.userID + '&questionID=' + questionID + '&data=' + postParams.data + '&answerID=' + postParams.answerID + '';
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
