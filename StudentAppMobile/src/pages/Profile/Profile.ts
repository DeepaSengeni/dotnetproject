import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController, ModalController } from 'ionic-angular';
import { UsersInfoProvider } from '../../providers/Users/UsersInfo';
import { FriendsPage } from '../Friends/Friends';
import { NoteBookListPage } from '../NoteBookList/NoteBookList';
import { NotebookPageDetailsPage } from '../NotebookPageDetails/NotebookPageDetails';
import { NotebookProvider } from '../../providers/Notebook/Notebook';
import { EditprofileForm } from '../EditprofileForm/EditprofileForm';
import { updateprfilepicPage } from '../modals/updateprfilepic/updateprfilepic';
import { updatecoverpicPage } from '../modals/updatecoverpic/updatecoverpic';
import { FriendsProvider } from '../../providers/Friends/Friends';
import { config } from '../../app/config';

/*
  Generated class for the Profile page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
  selector: 'page-Profile',
  templateUrl: 'Profile.html'
})
export class ProfilePage {


  datalistdata: any[];
  data: string[];
  bookdata: string[];
  bookLists: any = [];
  user: any;
  coverimage: any;
  profileimage: any;
  dLenght = 0;
  id;
  userid;
  friendrequestdata: any;
  Status: any;
  showdata: any;
  friendData: any;
  checkid: any;
  CurrentUserfriendIds: any = [];
  CurrentUserFriendRequestIds: any = [];
  friendStatus: any = [];
  PageIds: any = [];
  show: any;
  PageId: any;
  usershow: any;
  friendrequestId: any;
  cimg: any;
  url = config.apiUrl;

  constructor(public navCtrl: NavController, public friendServices: FriendsProvider, public navParams: NavParams, public loadingCtrl: LoadingController, public UserinfoService: UsersInfoProvider, public alertctrl: AlertController, public modalCtrl: ModalController, public NotebookServices: NotebookProvider) {
    this.userid = window.localStorage.getItem('Userid');

    this.coverimage = window.localStorage.getItem('coverimage');
    this.user = navParams.get('id');
    console.log("Page enter :" + this.user);
    if (this.user != undefined) {
      this.id = navParams.get('id');
    }
    else {
      this.id = this.navParams.data;
    }
    console.log("Profilepage:" + this.id);

  }

  ionViewDidLoad() {
    //console.log('ionViewDidLoad ProfilePage');
    this.GetProfile(this.id);
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
      console.log("success" + success.ResponseData);
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
        this.friendData = this.data;
        if (this.friendData.length > 0) {
          for (let i = 0; i < this.friendData.length; i++) {
            this.friendrequestId = this.friendData[i].FriendRequestId;
          }
        }
      }
      this.FriendsRequest();
    });
  }

  FriendsRequest() {
    this.friendServices.Friendrequests(this.userid).then(success => {
      this.dLenght = success.ResponseData.length
      console.log("success" + success.ResponseData);
      if (success.ResponseData.length > 0) {
        this.friendrequestdata = JSON.parse(success.ResponseData);
        for (let i = 0; i < this.friendrequestdata.length; i++) {
          this.Status = this.friendrequestdata[i].Status;
        }

      }
      this.test();
    });
  }

  BookDetails(value: any): void {
    let myModal = this.modalCtrl.create(NotebookPageDetailsPage);
    myModal.present();
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
      this.unfriend(FriendRequestId);
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

  unfriend(id) {
    this.friendServices.unfriend(id).then(success => {
      if (success.IsSuccess == true) {
        this.GetProfile(this.id);
      }
      else {
        alert("Fail");
      }
    });
  }

  SendFriendRequest(id) {
    this.friendServices.FriendList_InsertUpdate(this.userid, id).then(success => {
      if (success.IsSuccess == true) {
        this.GetProfile(this.id);
      }
      else {
        alert("Fail");
      }
    });
  }

  Invitefriends(id) {
    this.friendServices.InviteFriend(this.userid, id, this.PageId).then(success => {
      if (success.IsSuccess == true) {
        this.GetProfile(this.id);
      }
      else {
        alert("Fail");
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



}
