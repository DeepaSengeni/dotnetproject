import { Component } from '@angular/core';
import { NavController, NavParams, ViewController, Platform } from 'ionic-angular';
import { UsersInfoProvider } from '../../../providers/Users/UsersInfo';
import { CommonProvider } from '../../../providers/Common/common';
import { GlobalProvider } from '../../../providers/globalvariable/GlobalUserId';
import { HomeIndexPage } from '../../home-index/home-index';
import { config } from '../../../app/config';
/*
  Generated class for the DataNotification page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-DataNotification',
    templateUrl: 'DataNotification.html'
})
export class DataNotificationPage {

  notificationData;
  items;
  url = config.apiUrl;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public platform: Platform,
    public params: NavParams,
    public viewCtrl: ViewController,
    public commonInfo: CommonProvider,
    public globalvariable: GlobalProvider,
    public userinfo: UsersInfoProvider
  )
  {

    this.notificationData = this.params.get('notification');   
  }

    ionViewDidLoad() {
      //console.log('ionViewDidLoad DataNotificationPage');
      console.log('ionViewDidLoad notification_modalPage');
     // console.log(this.notificationData.data);
      this.items = this.notificationData.data;
      //let userid = localStorage.getItem("userId");
      let userid= this.globalvariable.LoggedInUserId;
      let type = "invitationLi";
      this.commonInfo.Invitation_FriendRequest_Notification_List_IsRead_Update(userid, type).then(success => {
      }, (error) => {
        console.log(error);
      });
    }
  opendetails(pageId, Bookid)
  {
    this.navCtrl.push(HomeIndexPage, { pageId: pageId, Bookid: Bookid });
  }

  dismiss() {
    this.viewCtrl.dismiss();
  }

  UpdateNotificationStatus(obj, status, Type) {
    this.userinfo.Invitation_FriendRequest_Notification_List_IsRead_Update(obj, status, Type).then(success =>
    {
      this.items = this.notificationData.data;
    }, (error) => {
      console.log(error);
    });


  }

}
