import { Component, ViewChild  } from '@angular/core';
import { Nav, Platform } from 'ionic-angular';
import { StatusBar, Splashscreen } from 'ionic-native';
import { db } from '../providers/db/db';

import { config } from './config';
import { SignIn } from '../pages/sign-in/sign-in';
import { Home } from '../pages/home/home';
import { AddBook } from '../pages/add-book/add-book';
import { Account } from '../pages/account/account';
import { NotebookFormPage } from '../pages/NotebookForm/NotebookForm';
//import { NotebookPageDetailsPage } from '../pages/NotebookPageDetails/NotebookPageDetails';
import { ProfilePage } from '../pages/Profile/Profile';
import { FriendsPage } from '../pages/Friends/Friends';
import { NoteBookListPage } from '../pages/NoteBookList/NoteBookList';
import { TabForProfileFriendPage } from '../pages/TabForProfileFriend/TabForProfileFriend';
import { EditprofileForm } from '../pages/EditprofileForm/EditprofileForm';
import { AdCreateForm } from '../pages/AdCreateForm/AdCreateForm';
import { HomeIndexPage } from '../pages/home-index/home-index';
import { LogoutPage } from '../pages/logout/logout';
import { PaypalPage } from '../pages/paypal/paypal';
import { ImagesavepopupPage } from '../pages/Imagesavepopup/Imagesavepopup';

import { AddNotebookPage } from '../pages/add-notebook/add-notebook';
import { FaqPage } from '../pages/modals/Faq/Faq';
import { SettingPage } from '../pages/Setting/Setting';

@Component({
  templateUrl: 'app.html'
})
export class MyApp {
 
  @ViewChild(Nav) nav: Nav;

  rootPage: any = SignIn;

  pages: Array<{ title: string, icon: string, component: any, params :any }>;

  currentuser: any;
  profileimage: any;
  username: any;

  constructor(public platform: Platform, public database: db) {
    this.initializeApp();
    
    // used for an example of ngFor and navigation
    this.pages = [
      { title: 'Home', icon: 'home', component: Home, params:'' },
      { title: 'Creator\'s Account', icon: 'settings', component: Account, params: ''},
      { title: 'Profile', icon: 'person', component: TabForProfileFriendPage, params: ''  },
      { title: 'Friends', icon: 'people', component: FriendsPage, params: '' },
      { title: 'FAQ', icon: 'information-circle', component: FaqPage, params: '' },
      { title: 'Create Ad', icon: 'create', component: AdCreateForm, params: '' },
      { title: 'Help 8787056761', icon: 'help', component: HomeIndexPage, params: '' },
      { title: 'Setting', icon: 'build', component: SettingPage, params: '' },
      { title: 'Sign Out', icon: 'log-out', component: LogoutPage, params: ''}
    ];

  }

  initializeApp() {
    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      StatusBar.styleDefault();
      Splashscreen.hide();
    });
  }

  openPage(page) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario    
    if (page.params != '' || page.params != undefined) {
      this.nav.setRoot(page.component, page.params);
      console.log(page.params);
    }
    else {
      this.nav.setRoot(page.component);
    }

  }

}



