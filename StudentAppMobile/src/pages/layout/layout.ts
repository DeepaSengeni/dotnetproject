import { Component } from '@angular/core';
import { NavController, ModalController, Platform, NavParams, ViewController } from 'ionic-angular';

import { LocalNotifications } from 'ionic-native';
import { FriendsProvider } from '../../providers/Friends/Friends';
import { NotificationModalPage } from '../modals/notification-modal/notification-modal';
import { FriendrequestNotificationPage } from '../modals/FriendrequestNotification/FriendrequestNotification';
import { DataNotificationPage } from '../modals/DataNotification/DataNotification';
import { Findfriend } from '../modals/Findfriend/Findfriend';
import { NotebookFormPage } from '../NotebookForm/NotebookForm';
import { db } from '../../providers/db/db';
import { CommonProvider } from '../../providers/Common/common';
import { GlobalProvider } from '../../providers/globalvariable/GlobalUserId';
import { config } from '../../app/config';

@Component({
    selector: 'page-layout',
    templateUrl: 'layout.html'
})
export class LayoutPage {

  notificationsCount: any;
  notificationsHtml: any;
  notificationData;
  isReadNotification: boolean;
  isReadNotificationfriendrequest: boolean;
  isReadNotificationinvite: boolean;
  notificationAlreadyReceived = false;
  userID: any;
  profileimage: any;
  username: any;
  friendRequestCount: any;
  dataCount: any;
  inputName: any;
  url = config.apiUrl;

  constructor(public navCtrl: NavController, public FriendService: FriendsProvider, public globalvariable: GlobalProvider, public navParams: NavParams, public commonService: CommonProvider, public modalCtrl: ModalController,
    public database: db) {
    this.isReadNotification = false;
    this.notificationsCount = 0;
    this.notificationsHtml = '';
    this.friendRequestCount = 0;
    this.dataCount = 0;
    var obj = this;
    this.userID = globalvariable.LoggedInUserId;
    
    this.profileimage = window.localStorage.getItem('profile');
   
    this.username = window.localStorage.getItem('name');
    
    this.getNotifications();

   setInterval(function(){      
        obj.getNotifications();    
      }, 10000);

    }

  ionViewDidLoad() {
      console.log('ionViewDidLoad layoutPage');     
    }

  openAddPage() {
    this.navCtrl.push(NotebookFormPage)
  }

  getNotifications() {
    this.commonService.NotificationsCount(this.userID).then(success => {    
      if (success.ResponseData.length > 0) {
        let jsonData = JSON.parse(success.ResponseData);
        this.notificationData = jsonData;
        if (jsonData.notifications.length > 0) {
          this.notificationsCount = JSON.parse(jsonData.notifications[0].UnreadNotifications);
          if (this.notificationsCount > 0) {
            this.isReadNotification = true;
            this.setnotification();
          }
        }
        if (jsonData.friendRequests.length > 0) {
          this.friendRequestCount = JSON.parse(jsonData.friendRequests[0].UnreadNotifications);
          if (this.friendRequestCount > 0) {
            this.isReadNotificationfriendrequest = true;
            this.setnotification();
          }
        }
        if (jsonData.data.length > 0) {
          this.dataCount = JSON.parse(jsonData.data[0].UnreadNotifications);
          if (this.dataCount > 0) {
            this.isReadNotificationinvite = true;
            this.setnotification();
          }
        }
      }
    }, (error) => {
    //  console.log(error);
    });
  }

  openNotificationModal() {
    let modal = this.modalCtrl.create(NotificationModalPage, { notification: this.notificationData });
    this.isReadNotification = false;
    modal.present();
  }

  openNotificationFriendrequests()
  {
    let modal = this.modalCtrl.create(FriendrequestNotificationPage, { notification: this.notificationData });
    this.isReadNotificationfriendrequest = false;
    modal.present();
  }

  openNotificationData()
  {
    let modal = this.modalCtrl.create(DataNotificationPage, { notification: this.notificationData });
    this.isReadNotificationinvite = false;
    modal.present();
  }

  setnotification() {
      if (this.notificationAlreadyReceived === false) {
        this.showNotification();
      }
  }

  showNotification() {
    LocalNotifications.schedule({
      text: 'You have new notifications',
    });
     this.notificationAlreadyReceived = true;
  }

  Findfriend()
  {
    let data = (document.getElementById('searchinput') as HTMLInputElement).value;
    let modal = this.modalCtrl.create(Findfriend, { "data": data});
    modal.present();
  }

  onInput(event:any)
  {
    this.inputName;
   // console.log("Call :  " + event);
  //  console.log("javascript : " + document.getElementById('searchinput'));
  }



}

