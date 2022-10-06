import { Injectable } from '@angular/core';

@Injectable()
export class GlobalProvider {

  public LoggedInUserId: any;

  constructor() {
    this.LoggedInUserId = parseInt(localStorage.getItem('Userid'));

    }

}
