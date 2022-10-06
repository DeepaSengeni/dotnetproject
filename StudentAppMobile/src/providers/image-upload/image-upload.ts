import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

import { config } from '../../app/config';
/*
  Generated class for the image_upload provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class ImageUploadProvider {

    constructor(public http: Http) {
        console.log('Hello image_upload Provider');
    }


  Upload(data): Promise<any> {
   var options = {
    };
    let body = new FormData();
    body.append('image', data);
    body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Authentication/UploadStudentProfilePic';
    return new Promise((resolve, reject) => {
      this.http.post(link, body, options)      
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

  Audioupload(data)
  {
   var options = {
  };
   let body = new FormData();
   body.append('audio', data);
   body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Book/UploadAudioFile';

return new Promise((resolve, reject) => {
  this.http.post(link, body, options)
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

  Updateprofile(data,name)
  {
    var options = {
    };
    let body = new FormData();
    body.append('image', data);
    body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Users/Update_Picture?filename='+name+'';

    return new Promise((resolve, reject) => {
      this.http.post(link, body, options)
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

  updatepicindb(userid, ProfileImage)
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams =
      {
        userid: userid,
        ProfileImage: ProfileImage,
      };
    var link = '' + config.apiUrl + '/api/Users/USP_U_UsersProfilePic?userid=' + postParams.userid + '&ProfileImage=' + postParams.ProfileImage + '';
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

  UpdateCoverPic(userid, ProfileImage) {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams =
      {
        userid: userid,
        ProfileImage: ProfileImage,
      };
    var link = '' + config.apiUrl + '/api/Users/Update_CoverPic?id=' + postParams.userid + '&coverimage=' + postParams.ProfileImage + '';
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



