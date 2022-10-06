import { Component } from '@angular/core';
import { NavController, NavParams, ViewController, Config, AlertController, ToastController, ModalController } from 'ionic-angular';
import { FriendsProvider } from '../../../providers/Friends/Friends';
import { GlobalProvider } from '../../../providers/globalvariable/GlobalUserId';
import { config } from '../../../app/config';
import { TabForProfileFriendPage } from '../../TabForProfileFriend/TabForProfileFriend';
import { ProfilePage } from '../../Profile/Profile';

/*
  Generated class for the Findfriend page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-Findfriend',
    templateUrl: 'Findfriend.html'
})
export class Findfriend {
  userID: any;
  Text: any;
  CurrentUserfriendIds: any = [];
  CurrentUserFriendRequestIds: any = [];
  friendStatus: any = [];
  PageIds: any = [];
  usershow: any;
  show: any;
  frienddata: string[];
  friendlistdata: any[];
  data: any;
  friendData: any;
  dLenght = 0;
  friendrequestdata: any;
  PageId: any;
  friendreqid: any;
  cssclass: any;
  url = config.apiUrl;
  l: any=[];

  constructor(public navCtrl: NavController, public modalCtrl: ModalController, public toastctrl: ToastController, public alertctrl: AlertController, public navParams: NavParams, public viewCtrl: ViewController, public globalvariable: GlobalProvider, public FriendService: FriendsProvider)
  {
    this.userID = globalvariable.LoggedInUserId;
    this.Text = this.navParams.get("data");
    this.friendreqid = 0;
    this.findfriend();

  //  this.FriendsList();
  }
    ionViewDidLoad() {
      //  console.log('ionViewDidLoad FindfriendPage');
    }

  dismiss() { this.viewCtrl.dismiss(); }

  findfriend()
  {
    this.FriendService.findfriend(this.Text, this.userID).then((success) => {
      var response = JSON.parse(JSON.stringify(success));
      //console.log(response);
      //console.log("IsSuccess  : "+ response.IsSuccess)
      if (response.IsSuccess == true) {
        //console.log("Inside");
        var jsondaat = (JSON.parse(response.ResponseData));
        //console.log(jsondaat);
        //console.log("FriendRequest   : " + jsondaat.FriendRequest)
        this.friendrequestdata = jsondaat.FriendRequest;
      //  console.log("FriendList   : " + jsondaat.Profile)
        this.friendData = jsondaat.Profile;
      }
      else
      {

    //    console.log("Outside");
      }
      this.test();

    }, error => { /*alert(JSON.stringify(error))*/ });
  }


  test() {
    var PageId = "0";
    if (this.PageId != undefined) {
      PageId = this.PageId;
      var t = "";
      //t = PageId.toString();
    }
    var blank = [];
    if (this.friendrequestdata.length > 0 && this.friendData.length > 0) {
      if (this.friendrequestdata.length > 0) {
        for (let i = 0; i < this.friendrequestdata.length; i++) {
          this.CurrentUserfriendIds[i] = ((this.friendrequestdata[i].id) > 0) ? parseInt(this.friendrequestdata[i].id) : 0;
          this.CurrentUserFriendRequestIds[i] = ((this.friendrequestdata[i].FriendRequestId) > 0) ? parseInt(this.friendrequestdata[i].FriendRequestId) : 0;
          this.friendStatus[i] = ((this.friendrequestdata[i].Status) != "" ? (this.friendrequestdata[i].Status) : "");
        }
      }
      // console.log(this.CurrentUserfriendIds);
      var index1 = this.CurrentUserfriendIds.indexOf((this.CurrentUserfriendIds, parseInt(this.userID)));
      var status1 = "";
      var friendRequestId1 = 0;
      if (index1 > -1) {
        status1 = this.friendStatus[index1];
        friendRequestId1 = this.CurrentUserFriendRequestIds[index1];
      }

      if (this.friendData.length > 0) {
        for (let i = 0; i < this.friendData.length; i++) {

          if (this.friendData[i].id != parseInt(this.userID)) {
            var index2 = this.CurrentUserfriendIds.indexOf((this.CurrentUserfriendIds, this.friendData[i].id));
            var CurrentUserFriendRequestIds2 = 0;
            if (index2 > -1) {
              CurrentUserFriendRequestIds2 = this.CurrentUserFriendRequestIds[index2];
            }
            this.friendData[i].ProfileImage;
            var index = index2;
            if (index > -1) {
              var status = this.friendStatus[index];
              var CurrentUserFriendRequestIds1 = this.CurrentUserFriendRequestIds[index];
              if (status == "1") {
                this.friendreqid = CurrentUserFriendRequestIds1;
                this.l.push({
                  id: this.friendData[i].id,
                  ProfileImage: this.friendData[i].ProfileImage,
                  FirstName: this.friendData[i].FirstName,
                  LastName: this.friendData[i].LastName,
                  CountryName: this.friendData[i].CountryName,
                  StateName: this.friendData[i].StateName,
                  CityName: this.friendData[i].CityName,
                  cssclass: "unfriendclass",
                  show: "Unfriend",
                  friendreqid: this.friendreqid
                });
              }
              else {
                if (status == "2") {
                  this.l.push({
                    id: this.friendData[i].id,
                    ProfileImage: this.friendData[i].ProfileImage,
                    FirstName: this.friendData[i].FirstName,
                    LastName: this.friendData[i].LastName,
                    CountryName: this.friendData[i].CountryName,
                    StateName: this.friendData[i].StateName,
                    CityName: this.friendData[i].CityName,
                    cssclass: "sendfriendrequestcss",
                    show: "Send friend request",
                    friendreqid: 0
                  });
                }
                else {                
                  this.friendreqid = CurrentUserFriendRequestIds1;
                  this.l.push({
                    id: this.friendData[i].id,
                    ProfileImage: this.friendData[i].ProfileImage,
                    FirstName: this.friendData[i].FirstName,
                    LastName: this.friendData[i].LastName,
                    CountryName: this.friendData[i].CountryName,
                    StateName: this.friendData[i].StateName,
                    CityName: this.friendData[i].CityName,
                    cssclass: "alreadyrequestsent",
                    show: "Friend request sent",
                    friendreqid: this.friendreqid
                  });
                }
              }
            }
            else {
              this.l.push({
                id: this.friendData[i].id,
                ProfileImage: this.friendData[i].ProfileImage,
                FirstName: this.friendData[i].FirstName,
                LastName: this.friendData[i].LastName,
                CountryName: this.friendData[i].CountryName,
                StateName: this.friendData[i].StateName,
                CityName: this.friendData[i].CityName,
                cssclass: "sendfriendrequestcss",
                show: "Send friend request",
                friendreqid: 0
              });
            }
          }
        }
      }
    }
  }
  Dynamicclick(value, id, FriendRequestId)
  {
    if (value == "Unfriend") {
      this.openUnfriendPop(FriendRequestId);
    }
    else if (value == "Send friend request") {
      this.SendFriendRequest(id);
    }
    else if (value == "Send invitation") {
    }
    else if (value == " Invitation sent ") {
      const alert = this.alertctrl.create({
        title: 'Invitation!',
        subTitle: 'Invitation already sent!',
        buttons: ['OK']
      });
      alert.present();

    }
    else if (value == "Friend request sent") {
      const alert = this.alertctrl.create({
        title: 'Friend Request!',
        subTitle: 'Friend Request already sent!',
        buttons: ['OK']
      });
      alert.present();
    }

    //  alert(value +"  :And:  "+id);
  }

  SendFriendRequest(id) {
    this.FriendService.FriendList_InsertUpdate(this.userID, id).then(success => {
      if (success.IsSuccess == true) {
        let toast = this.toastctrl.create({
          message: 'FriendRequest send Successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
      //  this.GetProfile(this.id);
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

  openUnfriendPop(id) {
    let self = this;
    let prompt = this.alertctrl.create({
      message: "Are you sure to remove this friend.",
      cssClass: 'alert-Custom',
      buttons: [
        {
          text: "No",
          handler: data => {
        //    console.log("Cancel");
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

  unfriend(id) {
    this.FriendService.unfriend(id).then(success => {
      if (success.IsSuccess == true) {
        let toast = this.toastctrl.create({
          message: 'Unfriend Successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
      //  this.GetProfile(this.id);
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
  openProfile(userid: any)
  {
  //  let contactModal = this.modalCtrl.create(TabForProfileFriendPage, { id: userid });
    //   contactModal.present();
    this.navCtrl.push(TabForProfileFriendPage, { id: userid });

  }



}
