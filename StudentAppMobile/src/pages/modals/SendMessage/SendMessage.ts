import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController } from 'ionic-angular';
import { CommonProvider } from '../../../providers/Common/common';
import { NotebookProvider } from '../../../providers/Notebook/Notebook';
/*
  Generated class for the SendMessage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-SendMessage',
    templateUrl: 'SendMessage.html'
})
export class SendMessagePage {

  pageid: any;
  bookid: any;
  userid: any;
  data: any;
  data2: any;
  message: any;
  count: any;
  Id: any;
  addmore: any = false;
  intTextBox = 0;

  constructor(public navCtrl: NavController, public navParams: NavParams,
    public CommonService: CommonProvider,
    public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
    public NotebookServices: NotebookProvider,
  )
  {
    this.pageid = navParams.get('pageId');    
    this.bookid = navParams.get('Bookid');
    this.userid = window.localStorage.getItem('Userid');
    this.NotebookLoadByNotebookid();
    this.loadMessage();
  }

    ionViewDidLoad() {
        console.log('ionViewDidLoad SendMessagePage');
    }
  loadMessage()
  {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
  //  var name = window.localStorage.getItem("name");
    var name = "siddhartha";

    this.CommonService.Message_Load(parseInt(this.userid), this.bookid, this.pageid, name).then(success => {
      console.log(success);
      console.log(success.Message);
      this.message = success.Message;
      if (success.IsSuccess == true)
      {
        this.data = JSON.parse(success.ResponseData);
      }
      this.Id = parseInt(this.data[0]["Id"]);
       this.count = this.data.Count > 1 ? parseInt(this.data[0]["MessageCount"]) : 0;
    },
      (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: '"Error in uploading File"',
          buttons: ['OK']
        });
        alert.present();
        console.log(error);

      });
  }

  NotebookLoadByNotebookid() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.NotebookServices.NotebookDetailsByBookId(parseInt(this.bookid)).then(success => {
      console.log(success);
      if (success.IsSuccess == true) {
        this.data2 = JSON.parse(success.ResponseData);
       
      }
      console.log(":::::::::" + this.data2);
      console.log(this.data2[0].SubjectName);
      console.log(this.data2[0].StudentName);
      this.data2[0].StudentName;
     
   
    },
      (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: '"Error in uploading File"',
          buttons: ['OK']
        });
        alert.present();
        console.log(error);

      });
  }

  SendSMS()
  {
    //mobileno
    let mobileNumbers = ((document.getElementById("mobileno") as HTMLInputElement).value);
    this.CommonService.SendSMSToMobile(mobileNumbers, this.message, this.count).then(success => {
      console.log(success);
    });
  }

  Add()
  {
  this.addmore = true;
  this.intTextBox++;
    var objNewDiv = document.createElement('div');
    objNewDiv.setAttribute('class', 'sendmessage');
    objNewDiv.setAttribute('id', 'div_' + this.intTextBox);
   objNewDiv.innerHTML = ' <input type="text" placeholder="Please Enter Mobile Number" class="mobileno" id="tb_' + this.intTextBox + '" name="tb_' + this.intTextBox + '"/>';
    document.getElementById('searchfilters').appendChild(objNewDiv);
}

  removeElement()
  {
  
      document.getElementById('txtadd').removeChild(document.getElementById('div_' + this.intTextBox));
      if (this.intTextBox == 1)
      {
        this.addmore = false;
      }
    this.intTextBox--;

}

}
