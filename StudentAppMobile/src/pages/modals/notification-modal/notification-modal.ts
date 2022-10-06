import { Component } from '@angular/core';
import { NavController, NavParams, ModalController, Platform, ViewController } from 'ionic-angular';

import { CommonProvider } from '../../../providers/Common/common';
import { UsersInfoProvider } from '../../../providers/Users/UsersInfo';
import { HomeIndexPage } from '../../home-index/home-index';
import { config } from '../../../app/config';

@Component({
    selector: 'page-notification_modal',
    templateUrl: 'notification-modal.html'
})
export class NotificationModalPage {

  notificationData;
  items;
  url = config.apiUrl;
  userid = localStorage.getItem("userId");
  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public platform: Platform,
    public params: NavParams,
    public viewCtrl: ViewController,
    public usersInfo: UsersInfoProvider,
    public common: CommonProvider
  )
  {
    this.notificationData = this.params.get('notification');
    this.Notificationlist();
  }

    ionViewDidLoad() {
      console.log('ionViewDidLoad notification_modalPage');
      console.log(this.notificationData.notifications);
   //   this.items = this.notificationData.notifications;
     
      let type = "notificationLi";
      this.common.Invitation_FriendRequest_Notification_List_IsRead_Update(this.userid, type).then(success => { });

    }

  Notificationlist()
  {
    this.common.NotificationList(this.userid).then(success => {
      this.items = JSON.parse(success.ResponseData);
    }, (error) => {
      console.log(error);
    });
  }

  dismiss() {
    this.viewCtrl.dismiss();
  }
  HomeIndex(pageId, Bookid)
  {
    this.navCtrl.push(HomeIndexPage, { pageId: pageId, Bookid: Bookid });
  }

}


