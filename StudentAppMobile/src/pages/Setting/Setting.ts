import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController, ToastController, Config, MenuController   } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators, ValidatorFn, AbstractControl, FormControl } from '@angular/forms';
import { GlobalProvider } from '../../providers/globalvariable/GlobalUserId';
import { AuthenticationProvider } from '../../providers/authentication/authentication';
import { OTPProvider } from '../../providers/otp/otp';
import { UsersInfoProvider } from '../../providers/Users/UsersInfo';
import { CommonProvider } from '../../providers/Common/common';
import { db } from '../../providers/db/db';
import { global } from '@angular/core/src/facade/lang';
import { Home } from '../home/home';
import { LogoutPage } from '../logout/logout';

@Component({
    selector: 'page-Setting',
    templateUrl: 'Setting.html'
})
export class SettingPage {

  settingform: FormGroup;
  Userid: any;
  txtSendOTP: string = "Send OTP";
  datalistdata: any[];
  data: string[];
  send: boolean = false;
  verify: boolean = false;

  constructor(public navCtrl: NavController, public commonservices: CommonProvider, public authenticationService: AuthenticationProvider, public UserServices: UsersInfoProvider, public globalvariable: GlobalProvider, public navParams: NavParams, public formBuilder: FormBuilder, public OTPService: OTPProvider, public loadingCtrl: LoadingController, public alertCtrl: AlertController, public database: db, public toastctrl: ToastController)
  {
    this.Userid = globalvariable.LoggedInUserId;
    this.settingform = formBuilder.group({
      Email: ['', Validators.compose([Validators.required]),
        this.isEmailUnique.bind(this)
      ],
      mobile: ['', Validators.compose([Validators.required]),
        this.ismobileUnique.bind(this)
      ],
      OTP: ['', Validators.compose([Validators.required])],
      regPassword: ['', Validators.compose([Validators.required])],
      ConfirmPassword: new FormControl('', [Validators.required, this.equalto('regPassword')]),
     
    });
  }

  ionViewDidLoad() {
      this.UserDetails();
  }

  UserDetails()
  {
    this.UserServices.GetUserInfo(this.Userid).then(success => {

      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
        this.datalistdata = this.data;
        this.settingform.setValue({
          Email: this.datalistdata[0].EmailId,
          mobile: this.datalistdata[0].MobileNumber,
          OTP:"",
          regPassword: this.datalistdata[0].Password,
          ConfirmPassword: this.datalistdata[0].Password,
        });

      }
    },
      (error) => {
        let alert = this.alertCtrl.create({
          title: 'Service Error',
          subTitle: error,
          buttons: ['Continue']
        });
        alert.present();
      });
  }

  checkvalue()
  {
    var ht = ((document.getElementById("samevalue") as HTMLFormElement).checkValidity);
    alert(ht);
    //var t = document.getElementById("#samevalue");

  }

  isEmailUnique(control: FormControl) {
    return new Promise(resolve => {
      this.authenticationService.isEmailExist(control.value).then((res) => {
        if (res.IsSuccess === true)
        {
          resolve({ 'isEmailUnique': true });
        }
        else {
          resolve(null);
        }
      },
        (err) =>
        {
        resolve({ 'isEmailUnique': true });
      });
    });
  }

  ismobileUnique(control: FormControl) {
    return new Promise(resolve => {
      this.authenticationService.isEmailExist(control.value).then((res) => {
        if (res.IsSuccess === true) {
          resolve({ 'ismobileUnique': true });
        }
        else {
          resolve(null);
        }
      }, (err) => {
        resolve({ 'ismobileUnique': true });
      });
    });
  }

  equalto(field_name): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      let input = control.value;
      let isValid = control.root.value[field_name] == input
      if (!isValid)
        return { 'equalTo': { isValid } }
      else
        return null;
    };
  }

  Setting(value: any): void {

    if (this.settingform.valid) {

      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      //loading.present();
      this.commonservices.Setting(this.Userid, value.Email, value.regPassword, value.mobile).then(success => {
        loading.dismiss();
        if (success.IsSuccess == true) {
          let alert = this.alertCtrl.create({
            title: 'Success',
            subTitle: "Setting changes are done.",
            buttons: ['OK']
          });
          alert.present();
          this.navCtrl.setRoot(Home);
        }
        else
        {
          let alert = this.alertCtrl.create({
            title: 'Failed',
            subTitle: "Fail to setting changes.",
            buttons: ['OK']
          });
          alert.present();
        }
      }, (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: 'Failed',
          //subTitle: error,
          buttons: ['OK']
        });
        alert.present();
        //   console.log(error);
      });
    }
  }

  sendOTP() {
    this.txtSendOTP = "Resend OTP";
    this.send = false;
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let mobileNumber = this.settingform.controls['mobile'].value; 
    this.OTPService.SendOTP(mobileNumber).then(success => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'OTP Send',
        buttons: ['OK']
      });
      alert.present();
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',     
        buttons: ['OK']
      });
      alert.present();     
    });
  }

  verifyOTP() {
    this.verify = false;
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let OTP = this.settingform.controls['OTP'].value;
   
    this.OTPService.VerifyOTP(OTP).then(success => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Mobile Number varified',
        buttons: ['OK']
      });
      alert.present();
      this.verify = true;
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        buttons: ['OK']
      });
      alert.present();  
    });
  }

  Delete()
  {
      let self = this;
      let prompt = this.alertCtrl.create({
        message: "Are you sure to delete this Account.",
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
           //   self.unfriend(id);
            }
          }
        ]
      });
      prompt.present();
}

  DeleteAccount()
  {
    this.commonservices.DeleteAccount(this.Userid).then(success =>
    {
      if (success.ResponseData.IsSuccess == true) {
        this.navCtrl.push(LogoutPage);
      }
      else
      {
        let alert = this.alertCtrl.create({
          title: 'Sorry !',
          subTitle: "Sorry this time not possible",
          buttons: ['OK']
        });
        alert.present();
      }
    }, error => {
      let alert = this.alertCtrl.create({
        title: 'Sorry !',
        subTitle: "Sorry this time not possible",
        buttons: ['OK']
      });
      alert.present(); });
  }


}
