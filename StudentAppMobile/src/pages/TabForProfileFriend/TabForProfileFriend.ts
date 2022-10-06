import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { ProfilePage } from '../Profile/Profile';
import { FriendsPage } from '../Friends/Friends';
import { NoteBookListPage } from '../NoteBookList/NoteBookList';
/*
  Generated class for the TabForProfileFriend page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-TabForProfileFriend',
    templateUrl: 'TabForProfileFriend.html'
})
export class TabForProfileFriendPage {

  fooId: any;

  constructor(public navCtrl: NavController, public navParams: NavParams) {
   // this.navParams = navParams;    

    if (navParams.get('id') != null && navParams.get('id') != undefined && navParams.get('id') != '') {
      this.fooId = navParams.get('id');
    }
    else {
      this.fooId = window.localStorage.getItem('Userid');   
    }
   
  }
  ionViewDidLoad() {
//    console.log('ionViewDidLoad TabForProfileFriendPage');
  }
  tab1Root = ProfilePage;
  tab2Root = FriendsPage;
  tab3Root = NoteBookListPage;
    
}
