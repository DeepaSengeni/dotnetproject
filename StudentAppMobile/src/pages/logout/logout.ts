import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { AuthenticationProvider } from '../../providers/authentication/authentication';
import { db } from '../../providers/db/db';
import { SignIn } from '../sign-in/sign-in';
import { GlobalProvider } from '../../providers/globalvariable/GlobalUserId';


/*
  Generated class for the logout page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-logout',
    templateUrl: 'logout.html'
})
export class LogoutPage {

  userId: any;

  constructor(public navCtrl: NavController,
    public navParams: NavParams,
    public authenticationProvider: AuthenticationProvider,
    public globalProvider: GlobalProvider,
    public database: db,
  ) {
    this.userId = globalProvider.LoggedInUserId;
    this.logoff(this.userId);
    }

    ionViewDidLoad() {
        console.log('ionViewDidLoad logoutPage');
    }

  logoff(id) {
    this.authenticationProvider.logOff(id).then(success => {
      if (success.IsSuccess == true) {
      this.globalProvider.LoggedInUserId = '';
      localStorage.setItem('Userid', '');
      localStorage.setItem('profile', '');
      localStorage.setItem('name', '');
      localStorage.setItem('username', '');
      localStorage.setItem('password', '');
      localStorage.setItem('Player_Image', '');
      localStorage.setItem('imagesrc', '');
      localStorage.setItem('imagefilesrcone', '');
      localStorage.setItem('submitvideosrc', '');
      localStorage.setItem('Player_Image', '');
        localStorage.setItem('videoscreensrc', '');
        this.database.LogoutUser().then(success => { });
      this.navCtrl.popAll()
      this.navCtrl.setRoot(SignIn);
     }
    }, (error) => {
      console.log(error);// Error getting the data   
    });
  }

}
