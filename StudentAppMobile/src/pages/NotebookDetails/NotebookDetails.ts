import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, ToastController, AlertController } from 'ionic-angular';
import { NotebookProvider } from '../../providers/Notebook/Notebook';
import { TabForProfileFriendPage } from '../TabForProfileFriend/TabForProfileFriend';
import { NotebookFormPage } from '../NotebookForm/NotebookForm';
import { Home } from '../home/home';
import { config } from '../../app/config';

/*
  Generated class for the NotebookDetails page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-NotebookDetails',
    templateUrl: 'NotebookDetails.html'
})
export class NotebookDetailsPage {
  id;
  userid;
  data: string[];
  dataLists: any = [];
  notebookowner: any;
  pages: any;
  loginuserid: any;
  optional: any;
  url = config.apiUrl;


  constructor( public navCtrl: NavController, public toastctrl: ToastController,  public navParams: NavParams, public loadingCtrl: LoadingController, public alertctrl: AlertController, public NotebookServices: NotebookProvider) {
    this.id = navParams.get('id');
  

    this.NotebookDetailsByBookId(this.id);
  }

  ionViewDidLoad() {
  //  console.log('ionViewDidLoad NotebookDetailsPage');

  }

  NotebookDetailsByBookId(id) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.NotebookServices.NotebookDetailsByBookId(id).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
        this.dataLists = this.data;
        this.loginuserid = window.localStorage.getItem('Userid');
        this.notebookowner = this.dataLists[0].UserId;
        this.optional=this.dataLists[0].Innovation_Investment;
    
        if (this.loginuserid == this.notebookowner) {
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

  profile(value:any)
  {
    localStorage.setItem("selectedUserId", value);
    this.navCtrl.push(TabForProfileFriendPage, { id: value });
  }

  Downloadbook(bookid) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.NotebookServices.Downloadbook(bookid).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
    
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

  presentConfirm() {
    let alert = this.alertctrl.create({
      title: 'Confirm Notebook Delete',
      message: 'Do you want to Delete this Notebook?',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
          //  console.log('Cancel clicked');
          }
        },
        {
          text: 'Confirm',
          handler: () => {
            this.DeleteBook();
       
          }
        }
      ]
    });
    alert.present();
  }

  DeleteBook() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let user = window.localStorage.getItem('Userid');
    this.NotebookServices.Deletebook(parseInt(user), parseInt(this.id)).then(success => {
      loading.dismiss();
      if (success.IsSuccess == true)
      {
        let toast = this.toastctrl.create({
          message: 'Book Deleted successfully',
          duration: 3000,
          position: 'bottom'
        });
        toast.present();
        this.navCtrl.setRoot(Home);
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

  Editbook()
  {
    this.navCtrl.push(NotebookFormPage, { bookid: this.id });
  }

  
}
