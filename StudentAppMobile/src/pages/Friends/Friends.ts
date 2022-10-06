import { Component } from '@angular/core';
import { NavController, NavParams, AlertController, LoadingController, ToastController } from 'ionic-angular';
import { FriendsProvider } from '../../providers/Friends/Friends';
import { UsersInfoProvider } from '../../providers/Users/UsersInfo';
import { EditprofileForm } from '../EditprofileForm/EditprofileForm';
import { updateprfilepicPage } from '../modals/updateprfilepic/updateprfilepic';
import { updatecoverpicPage } from '../modals/updatecoverpic/updatecoverpic';
import { config } from '../../app/config';

/*
  Generated class for the Friends page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
  selector: 'page-Friends',
  templateUrl: 'Friends.html'
})
export class FriendsPage {

  datalistdata: any[];
  frienddata: string[];
  friendlistdata: any[];
  friendrequestdata: any;
  data: string[];
  dLenght = 0;
  id: any;
  userid: any=0;
  friendData: any;
  user: any;
  coverimage: any;
  profileimage: any;
  friendimage: any;
  friendname: any;
  friendcity: any;
  friendcountry: any;
  friendstatus: any;
  FriendRequestId: any;
  PageId: any;
  Id: any;
  valuewrite: any;
  Status: any;
  CurrentUserfriendIds: any = [];
  CurrentUserFriendRequestIds: any = [];
  friendStatus: any = [];
  PageIds: any = [];
  show: any;
  trydata: any;
  usershow: any;
  url = config.apiUrl;
  Emptydata: any;



  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    public alertctrl: AlertController,
    public friendServices: FriendsProvider,
    public UserinfoService: UsersInfoProvider,
    public toastctrl: ToastController,
  ) {
    this.Emptydata = false;
    this.PageId = navParams.get('PageId');
    this.userid =parseInt( window.localStorage.getItem('Userid'));
    this.user = navParams.get('id');

    if (this.user != undefined) {
      this.id = navParams.get('id');
    }
    else if (this.navParams.data == "") {
      this.id = this.userid;
    }
    else if (this.navParams.data != undefined) {
      this.id = this.navParams.data;
      if (this.PageId != undefined) {
        this.id = this.userid;
      }
    }
  }

  ionViewDidLoad() {
  //  console.log('ionViewDidLoad FriendsPage');
    this.GetProfile(this.id);
   /// this.try();
   
  }

  GetProfile(id) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.UserinfoService.GetUserInfo(id).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
        this.datalistdata = this.data;
        this.coverimage = this.datalistdata[0].CoverImage;
        this.profileimage = this.datalistdata[0].ProfileImage;
      }
      this.FriendsList(this.id);
    },
      (error) => {
        let alert = this.alertctrl.create({
          title: 'Service Error',
          subTitle: error,
          buttons: ['Continue']
        });
        alert.present();
      });
  }

  FriendsList(id) {
    this.friendServices.FriendsList(id).then(success => {
      this.dLenght = success.ResponseData.length
   //   console.log("success" + success.ResponseData);
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
        this.friendData = this.data;
        this.FriendsRequest();
      }
      else
      {
        this.FriendsRequest();
      }
      if (success.ResponseData == "[]")
      {
        this.Emptydata = true;
      }
    });
  }

  FriendsRequest()
  {
    this.friendServices.Friendrequests(this.userid).then(success => {
      this.dLenght = success.ResponseData.length
  //    console.log("success" + success.ResponseData);
      if (success.ResponseData.length > 0) {
        this.friendrequestdata = JSON.parse(success.ResponseData);
        this.test();
      }
    
    });
  }

  try()
  {
    this.friendServices.FriendsListTest(this.userid,this.id).then(success => {
      this.dLenght = success.ResponseData.length
     // console.log("success" + success.ResponseData);
      if (success.ResponseData.length > 0) {
        this.trydata = JSON.parse(success.ResponseData);
        this.test();
      }

    });
  }


  changeimg() {
    this.navCtrl.push(updateprfilepicPage);
  }

  updatecoverimg() {
    this.navCtrl.push(updatecoverpicPage);
  }

  profileEdit(val: any) {
    this.navCtrl.push(EditprofileForm, { id: val });
  }

  Dynamic(value, id, FriendRequestId) {
    if (value == "Unfriend") {
      this.openUnfriendPop(FriendRequestId);
    }
    else if (value == "Send friend request") {

      this.SendFriendRequest(id);
    }
    else if (value == "Send invitation") {
      this.Invitefriends(id);
    }
    else if (value == "Invitation sent") {
      const alert = this.alertctrl.create({
        title: 'Invitation!',
        subTitle: 'Invitation already sent!',
        buttons: ['OK']
      });
      alert.present();

    }
    else if (value == "Friend request sent")
    {
      const alert = this.alertctrl.create({
        title: 'Friend Request!',
        subTitle: 'Friend Request already sent!',
        buttons: ['OK']
      });
      alert.present();
    }

  //  alert(value +"  :And:  "+id);
  }

  unfriend(id) {
    this.friendServices.unfriend(id).then(success => {
      if (success.IsSuccess == true) {
       
        let toast = this.toastctrl.create({
          message: 'Unfriend Successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
        this.GetProfile(this.id);
      }
      else {
        const alert = this.alertctrl.create({
          title: 'Unfriend!',
          subTitle: 'Unfriend request fail!',
          buttons: ['OK']
        });
        alert.present();
      }
    });
  }

  SendFriendRequest(id)
  {
    this.friendServices.FriendList_InsertUpdate(this.userid,id).then(success => {
      if (success.IsSuccess == true) {
        let toast = this.toastctrl.create({
          message: 'FriendRequest send Successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
        this.GetProfile(this.id);
      }
      else {
        const alert = this.alertctrl.create({
          title: 'Friend Request!',
          subTitle: 'Fail send to FriendRequest!',
          buttons: ['OK']
        });
        alert.present();
   
      }
    });
  }

  Invitefriends(id)
  {
    this.friendServices.InviteFriend(this.userid, id, this.PageId).then(success => {
      if (success.IsSuccess == true) {
        let toast = this.toastctrl.create({
          message: 'Invite friend Successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
        this.GetProfile(this.id);
      }
      else {
        const alert = this.alertctrl.create({
          title: 'Invitation Request!',
          subTitle: 'Invitation request fail!',
          buttons: ['OK']
        });
        alert.present();
      }
    });
  }

  test() {
    var PageId = "0";
    if (this.PageId != undefined) {
      PageId = this.PageId;
      var t = "";
      t = PageId.toString();
    }
    var blank = {};
    if (this.friendrequestdata.length > 0) {
      for (let i = 0; i < this.friendrequestdata.length; i++) {
        this.CurrentUserfriendIds[i] = ((this.friendrequestdata[i].Id) > 0) ? parseInt(this.friendrequestdata[i].Id) : 0;
        this.CurrentUserFriendRequestIds[i] = ((this.friendrequestdata[i].FriendRequestId) > 0) ? parseInt(this.friendrequestdata[i].FriendRequestId) : 0;
        this.friendStatus[i] = ((this.friendrequestdata[i].Status) != "" ? (this.friendrequestdata[i].Status) : "");
      }
    }

    var index1 = this.CurrentUserfriendIds.indexOf((this.CurrentUserfriendIds, parseInt(this.id)));
    var status1 = "";
    var friendRequestId1 = 0;
    if (index1 > -1) {
      status1 = this.friendStatus[index1];
      friendRequestId1 = this.CurrentUserFriendRequestIds[index1];
    }

    if (this.friendData.length > 0) {
      for (let i = 0; i < this.friendData.length; i++) {

        if (this.friendData[i].Id != parseInt(this.userid)) {
          var index2 = this.CurrentUserfriendIds.indexOf((this.CurrentUserfriendIds, this.friendData[i].Id));
          var CurrentUserFriendRequestIds2 = 0;
          if (index2 > -1) {
            CurrentUserFriendRequestIds2 = this.CurrentUserFriendRequestIds[index2];
          }
          this.friendData[i].ProfileImage;
          if ((PageId) != "0") {
            this.PageIds = this.friendData[i].PageId.split(',');

            var index = this.PageIds.indexOf(this.PageIds, t);
            if (index > -1) {
              this.show = "Invitation sent";
            }
            else {
              this.show = "Send invitation";
            }
          }
          else {
            //  var index = this.CurrentUserfriendIds.indexOf(this.CurrentUserfriendIds, this.friendData[i].Id);
            var index = index2;
            if (index > -1) {
              var status = this.friendStatus[index];
              var CurrentUserFriendRequestIds1 = this.CurrentUserFriendRequestIds[index];
              if (status == "1") {
                this.show = "Unfriend";
                console.log("Unfriend");
              }
              else {
                if (status == "2") {
                  this.show = " Send friend request";
                  console.log("Send friend request");
                }
                else {
                  this.show = "Friend request sent";
                }
              }
            }
            else {
              this.show = " Send friend request ";
            }
          }
        }
      }
    }


    if (index1 > -1) {
      if (status1 == "1") {
        this.usershow = "Unfriend";
      }
      else {
        if (status1 == "2") {
          this.usershow = "Send friend request";

        }
        else {
          this.usershow = "Friend request sent";
        }
      }
    }
    else {
      this.usershow = "Send friend request";
    }
  }

  openUnfriendPop(id) {
    let self = this;
    let prompt = this.alertctrl.create({
      message: "Are you sure to remove this friend.",
      cssClass: 'alert-Custom',
      buttons: [
        {
          text: "No",
          handler: data => {
      //      console.log("Cancel");
          }
        },
        {
          text: "Yes",
          handler: data => {
            self.unfriend(id);
          }
        }
      ]
    });
    prompt.present();
  };




}
