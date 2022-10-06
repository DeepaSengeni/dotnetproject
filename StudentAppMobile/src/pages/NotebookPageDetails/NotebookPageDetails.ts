import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController, ToastController } from 'ionic-angular';
import { ViewController } from 'ionic-angular';
import { NotebookProvider } from '../../providers/Notebook/Notebook';
import { AddNotebookPage } from '../add-notebook/add-notebook';
import { HomeIndexPage } from '../home-index/home-index';
import { isUndefined } from 'ionic-angular/util/util';
import { config } from '../../app/config';
/*
  Generated class for the NotebookPageDetails page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-NotebookPageDetails',
    templateUrl: 'NotebookPageDetails.html'
})
export class NotebookPageDetailsPage {

  data: string[];
  dataLists: any = [];
  BookPageDetails: any = [];
  id = 0;
  BookCreator: string[];
  optionsMap = [];
  optionsChecked = [];
  Pageid = 0;
  delbook: any = [];
  notebookowner:any;
  pages: any;
  loginuserid: any;
  audiosrc: any;
  videosrc: any;
  imagesrc: any;
  textsrc: any;
  pagetype: any;
  Id: any;
  pagenumber: any;
  ModifiedDate: any;
  Checked: any;
  url = config.apiUrl;
 
  
  constructor(public toastCtrl: ToastController,public navCtrl: NavController, public navParams: NavParams, public viewCtrl: ViewController, public loadingCtrl: LoadingController, public NotebookServices: NotebookProvider, public alertctrl: AlertController)
  {
    this.id = navParams.get('id');
    this.pages = false;
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad NotebookPageDetailsPage');
    this.NotebookDetailsByBookId(this.id);
    this.GetPageDetails_ByBookId(this.id);
  }

  closeModal() {
    this.viewCtrl.dismiss();
  }

  NotebookDetailsByBookId(id) {
  let loading = this.loadingCtrl.create({
    content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
  });
   this.NotebookServices.NotebookDetailsByBookId(id).then(success => {
  loading.dismiss();
  if (success.ResponseData.length > 0) {
    this.data = JSON.parse(success.ResponseData);
    this.dataLists = this.data;
    console.log(this.dataLists[0]);
    this.loginuserid = window.localStorage.getItem('Userid');
    this.notebookowner = this.dataLists[0].UserId;
  //  alert("loginuserid  :" + this.loginuserid + " , notebookowner  :" + this.notebookowner);
    if (this.loginuserid == this.notebookowner)
    {
      this.pages = true;
    }
  }
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

  GetPageDetails_ByBookId(id) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    loading.present();
    this.NotebookServices.GetPageDetails_ByBookId(id).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.BookPageDetails = JSON.parse(success.ResponseData);    
      }
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

  openForgotPop() {
    let self = this;
    let prompt = this.alertctrl.create({
      message: "Are you sure to delete these selected pages.",
      cssClass: 'alert-Custom',
      buttons: [
        {
          text: "No",
          handler: data => {
            console.log("Cancel");
          }
        },
        {
          text: "Yes",
          handler: data => {
            self.editPartyRolesSubmit();
          }
        }
      ]
    });
    prompt.present();
  };

  editPartyRolesSubmit()
  {
    this.BookPageDetails.forEach(role =>
    {
      if (role.Checked == true)
      {
        console.log('Id: ' + role.Id + ', Name: ' + role.Id + ', Checked: ' + role.Checked);
        this.delbook.push(role.Id);
      }
    });
    console.log(this.delbook);
    this.NotebookServices.RemovePageById(this.delbook).then(success => {
      if (success.IsSuccess == true)
      {
        this.GetPageDetails_ByBookId(this.id);
        let toast = this.toastCtrl.create({
          message: 'Page Removed Successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
        console.log("Delete Pages")
      }
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

  goToAddNotebook(value: any) {
    this.navCtrl.push(AddNotebookPage, { id: value });
  }
 
  pagedetails(value: any)
  {
   // alert(value);
    this.navCtrl.push(HomeIndexPage, { pageId: value, userid: this.notebookowner, Bookid: this.id});
  }

}
