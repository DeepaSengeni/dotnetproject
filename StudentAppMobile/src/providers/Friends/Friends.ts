import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { config } from '../../app/config';
import 'rxjs/add/operator/map';

/*
  Generated class for the Friends provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class FriendsProvider {

    constructor(public http: Http) {
        console.log('Hello Friends Provider');
    }

  FriendsList(userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/FriendListLoadByUserId?userid=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  Friendrequests(userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/FriendRequest_LoadByUserId?userid=' + userid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  unfriend(Id): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      ID: Id
    }
    var link = '' + config.apiUrl + '/api/Users/RemoveFriend?ID=' + Id + '';
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

  FriendsListTest(userid, id): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/StatusFriendRequest_LoadByUserId?userid=' + userid + '&Id=' + id + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  FriendList_InsertUpdate(userid,invid): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
         }
    var link = '' + config.apiUrl + '/api/Invitation/FriendList_InsertUpdate?userid=' + userid + '&invid='+invid+'';
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

  InviteFriend(userid, inviteduserid, pageId): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
    }
    var link = '' + config.apiUrl + '/api/Invitation/InvitationList_Insert?userid=' + userid + '&inviteduserid=' + inviteduserid + '&pageId=' + pageId+'';
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

  findfriend(text,userid)
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      data: text,
      userid: userid
    }
    var link = '' + config.apiUrl + '/api/Users/findfriend?data=' + text + '&userid=' + userid + '';
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


  findfriendlist(text): Promise<any> {
    var link = '' + config.apiUrl + '/api/Users/SearchStudent?data=' + text + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }



}
