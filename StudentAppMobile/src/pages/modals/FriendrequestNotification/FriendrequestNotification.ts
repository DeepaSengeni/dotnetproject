import { Component } from '@angular/core';
import { NavController, NavParams, ViewController, Platform } from 'ionic-angular';
import { UsersInfoProvider } from '../../../providers/Users/UsersInfo';
import { CommonProvider } from '../../../providers/Common/common';

import { config } from '../../../app/config';


@Component({
    selector: 'page-FriendrequestNotification',
    templateUrl: 'FriendrequestNotification.html'
})
export class FriendrequestNotificationPage {

  notificationData;
  items;
  url = config.apiUrl;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public platform: Platform,
    public params: NavParams,
    public viewCtrl: ViewController,
    public usersInfo: UsersInfoProvider
  ) {

    this.notificationData = this.params.get('notification');
  }

  ionViewDidLoad() {
        console.log('ionViewDidLoad DataNotificationPage');
        console.log('ionViewDidLoad notification_modalPage');
        console.log(this.notificationData.friendRequests);
        this.items = this.notificationData.friendRequests;
        let userid = localStorage.getItem("userId");
  //      let type = "friendLi";
  //      this.usersInfo.Invitation_FriendRequest_Notification_List_IsRead_Update(userid, type).then(success => {

  //       }, (error) => {
  //         console.log(error);
  //       });
  }
  opendetails(PageId, BookId) {
    alert(PageId + "  " + BookId);
  }

  dismiss() {
    this.viewCtrl.dismiss();
  }

  UpdateNotificationStatus(obj, status, Type)
  {
    this.usersInfo.Invitation_FriendRequest_Notification_List_IsRead_Update(obj, status, Type).then(success => {


    }, (error) => {
      console.log(error);
    });


  }



  
}

