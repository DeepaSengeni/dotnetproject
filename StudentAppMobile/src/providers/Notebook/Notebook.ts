import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import 'rxjs/add/operator/map';

import { config } from '../../app/config';
/*
  Generated class for the Notebook provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class NotebookProvider {
 
    constructor(public http: Http) {
        console.log('Hello Notebook Provider');
    }

  //create Notebook
  Notebookadd(notebookdteails): Promise<any>
  {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = notebookdteails;
    var link = '' + config.apiUrl + '/api/Common/NotebookDetails_Insert';
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

  NotebookUpdate(notebookdteails): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = notebookdteails;
    var link = '' + config.apiUrl + '/api/Common/NotebookDetails_Update';
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
  

  NoteBookList(userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Book/NotebookListLoadByUserId?userid=' + userid+'';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  NotesbookLoads(page): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/Notesbooks_Bind?pageno=' + page + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  NotebookLoad_ByNotebookId(Notebookid, Userid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/NotebookLoadById?Userid=' + Userid + '&id=' + Notebookid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  NotebookDetailsByBookId(Bookid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Common/Notesbook_Pages?BookId=' + Bookid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }
  
  GetPageDetails_ByBookId(Bookid): Promise<any> {
    var link = '' + config.apiUrl + '/api/Book/GetPageDetails_ByBookId?bookId=' + Bookid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  RemovePageById(Pageids): Promise<any> {
    console.log("Api Call Remove Book" + Pageids)
    var link = '' + config.apiUrl + '/api/Pages/RemovePageById?id=' + Pageids + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  NoteBookLoadBySubjectId(Subjectid): Promise<any> {
    console.log("Api Call Book Load" + Subjectid)
    var link = '' + config.apiUrl + '/api/Book/NotebookLoadBySubjectId?Subjectid=' + Subjectid + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  SearchNoteBookByName(Name,country,state,city): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      name: Name,
      country: country,
      state: state,
      city: city,
    }
    var link = '' + config.apiUrl + '/api/Book/SearchBooksByName?name=' + postParams.name + '&country=' + postParams.country + '&state=' + postParams.state + '&city=' + postParams.city + '';
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

  Downloadbook(BookId): Promise<any> {
    console.log("Api Call Remove Book" + BookId)
    var link = '' + config.apiUrl + '/api/Common/BookContentLoadByBookId?bookid=' + BookId + '';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  Deletebook(Userid,BookId): Promise<any> {
    console.log("Api Call Remove Book" + BookId)
    var link = '' + config.apiUrl + '/api/Common/Delete_NotebookForm?id=' + Userid + '&bookid='+BookId+'';
    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  pageimageupload(imageData, filename): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = {
      imageData: imageData,
      filename: filename,
    }
    var link = '' + config.apiUrl + '/api/Book/pageimageupload?imageData=' + postParams.imageData + '&filename=' + postParams.filename + '';
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

  AddNotebookpages(notebookdteails, screenshot, pageType, src): Promise<any> {
    var headers = new Headers();
    headers.append("Accept", 'application/json');
    headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    let postParams = notebookdteails;
    var link = '' + config.apiUrl + '/api/Book/AddNotebook?model' + postParams + '&screenshot=' + screenshot + '&hdnPageType=' + pageType + '&src=' + src + '';
    return new Promise((resolve, reject) => {
      this.http.post(link, postParams, options)
        .map(res => res.json()).toPromise()
        .then(data => {resolve(data);},err => {reject(err);});
    });
  }

  imgdata(data): Promise<any> {
    var options = {
    };
    let body = new FormData();
    body.append('picture', data);
    body.append('desc', "testing");
    var link = '' + config.apiUrl + '/api/Book/Imageinbase64';
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

}
