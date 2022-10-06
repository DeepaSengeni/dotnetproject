import { Component } from '@angular/core';
import { NavController, AlertController, LoadingController } from 'ionic-angular';
import { LayoutPage } from '../layout/layout';
import { CommonProvider } from '../../providers/Common/common';
import { AccountsettingProvider } from '../../providers/AccountSetting/Accountsetting';

@Component({
  selector: 'page-account',
  templateUrl: 'account.html'
})
export class Account {
  userid: any;
  wallet: any;
  data: any;
  Getdata: any;
  currencydata: any;
  PaypalEmail: any;
  PageList: any;
  paymentlist: any;
  ClickCount: any;
  show: any;

  
  constructor(public navCtrl: NavController, public alertCtrl: AlertController, public loadingCtrl: LoadingController, public CommonServiceProvider: CommonProvider, public AccountsettingServiceProvider: AccountsettingProvider) {
    this.wallet = 0;
    this.PaypalEmail = "";
    this.walletAmount();
 //   this.GetUserCountryDetail();
   // this.ShowpaypalEmail();
    this.GetPageList_ByUserId();
    this.LoadPaymentRequestList();
    this.show = false;
  }

  ShowpaypalEmail()
  {
    let loading = this.loadingCtrl.create({
    content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
  });
//loading.present();
    this.userid = window.localStorage.getItem('Userid');
    this.AccountsettingServiceProvider.ShowpaypalEmail_IU(this.userid).then(success => {
  loading.dismiss();
  if (success.ResponseData.length > 0) {
    this.Getdata = JSON.parse(success.ResponseData);
    this.PaypalEmail = this.Getdata[0].PaypalEmail;
  }
      this.GetUserCountryDetail();
}, (error) => {
  let alert = this.alertCtrl.create({
    title: 'Service Error',
    subTitle: error,
    buttons: ['Continue']
  });
  alert.present();
  this.GetUserCountryDetail();
});
  }
  
  paypalemail()
  {
    let self = this;
    let prompt = this.alertCtrl.create({
      title: "Paypal Email",
      cssClass: 'alert-Custom',
      inputs: [
        {
          name: "email",
          placeholder: "Paypal Email"
        },
      ],
      buttons: [
        {
          text: "Cancel",
          handler: data => {
       //     console.log("Cancel");
          }
        },
        {
          text: "Change",
          handler: data => {
            self.Changeemail(data.email);
          }
        }
      ]
    });
    prompt.present();
  }

  Changeemail(Email)
  {
    // this.verify = false;
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
   // console.log(Email);
    this.userid = window.localStorage.getItem('Userid');
    this.AccountsettingServiceProvider.UpdatePaypalEmail(this.userid, Email).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
   //     console.log(success.Message);
        let alert = this.alertCtrl.create({
          title: 'Paypal',
          subTitle: success.Message,
          buttons: ['Ok']
        });
        alert.present();
        this.walletAmount();
        this.GetUserCountryDetail();
        this.ShowpaypalEmail();
        this.GetPageList_ByUserId();
        this.LoadPaymentRequestList();
      }
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
  }
  
  walletAmount()
  {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.userid = window.localStorage.getItem('Userid');
    this.CommonServiceProvider.updatewallet(this.userid).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
      //  console.log("Wallet  : "+this.data);
        this.wallet = this.data[0].TotalAmount;
        this.ClickCount = this.data[0].ClickCount;

      }
      this.ShowpaypalEmail();
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
      this.ShowpaypalEmail();
      });

  }

  GetUserCountryDetail() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.userid = window.localStorage.getItem('Userid');
    this.CommonServiceProvider.GetCountryDetail(this.userid).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
   //     console.log(success.ResponseData);
        this.currencydata = JSON.parse(success.ResponseData);
      }
      this.GetPageList_ByUserId();
    //  console.log(this.currencydata);
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
  }

  GetPageList_ByUserId()
  {
  let loading = this.loadingCtrl.create({
    content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
  });
  //loading.present();
    this.userid = window.localStorage.getItem('Userid');
    this.AccountsettingServiceProvider.GetPageList_ByUserId(this.userid).then(success => {
    loading.dismiss();
    if (success.ResponseData.length > 0) {
      this.PageList = JSON.parse(success.ResponseData);
  //    console.log(this.PageList);
     // console.log(this.data[0].TotalAmount);
    //  this.wallet = this.data[0].TotalAmount;
    }
  }, (error) => {
    let alert = this.alertCtrl.create({
      title: 'Service Error',
      subTitle: error,
      buttons: ['Continue']
    });
    alert.present();
  });
  }

  LoadPaymentRequestList() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.userid = window.localStorage.getItem('Userid');
    this.AccountsettingServiceProvider.LoadPaymentRequestList(this.userid).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.paymentlist = JSON.parse(success.ResponseData);
      //  console.log(this.paymentlist);
        // console.log(this.data[0].TotalAmount);
        //  this.wallet = this.data[0].TotalAmount;
      }
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
  }

  Notebook()
  {
    this.show = false; 
  }

  Request()
  {
    this.show = true;

  }

  Transfer()
  {
    if (this.wallet == 0) {
      const alert = this.alertCtrl.create({
        title: 'Wallet!',
        subTitle: 'wallet amount cann not be 0 !',
        buttons: ['OK']
      });
      alert.present();
    }
    else if (this.PaypalEmail == "")
    {
      const alert = this.alertCtrl.create({
        title: 'PaypalEmail!',
        subTitle: 'Please enter your Paypal Email to transfer amount !',
        buttons: ['OK']
      });
      alert.present();
    }
  }


  }

 

