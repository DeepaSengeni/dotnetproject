import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { config } from '../../app/config';

/*
  Generated class for the location_info provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class LocationInfoProvider {

    constructor(public http: Http) {
        console.log('Hello location_info Provider');
    }

  GetCountries(): Promise<any> {

    var link = '' + config.apiUrl + '/api/Authentication/LoadCountry';    

    return new Promise(resolve => {     
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  GetStatesByCountry(id): Promise<any> {

    var link = '' + config.apiUrl + '/api/Authentication/LoadStateByCountryId?countryid=' + id + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  GetCitiesByState(id): Promise<any> {

    var link = '' + config.apiUrl + '/api/Authentication/LoadCityByStateId?stateid=' + id + '';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

  GetallSubjectlist(): Promise<any>
  {
    var link = '' + config.apiUrl + '/api/Common/SubjectLoad';

    return new Promise(resolve => {
      this.http.get(link)
        .subscribe(data => {
          resolve(data.json());
        });
    });
  }

}
