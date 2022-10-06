
import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController, ToastController, Config, MenuController  } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators, ValidatorFn, AbstractControl, FormControl } from '@angular/forms';
import { Home } from '../home/home';
import { FaqPage } from '../modals/Faq/Faq';
import { AuthenticationProvider } from '../../providers/authentication/authentication';
import { LocationInfoProvider } from '../../providers/location-info/location-info';
import { ImageUploadProvider } from '../../providers/image-upload/image-upload';
import { OTPProvider } from '../../providers/otp/otp';
import { db } from '../../providers/db/db';
import { PaypalPage } from '../paypal/paypal';
import { GlobalProvider } from '../../providers/globalvariable/GlobalUserId';
import { config } from '../../app/config';


@Component({
  selector: 'page-sign-in',
  templateUrl: 'sign-in.html'
})
export class SignIn {

  authForm: FormGroup;
  regForm: FormGroup;
  
  logoffuser: any;
  //countryOpts: { title: string, subTitle: string };
  //stateOpts: { title: string, subTitle: string };
  //cityOpts: { title: string, subTitle: string };
  CountryList: any;
  StateList: any;
  CityList: any;

  file: File;

  hdnImageData: any;
  send: boolean = false;
  txtSendOTP: string = "Send OTP";
  verify: boolean = false;
  mobileNumber: any;
  url = config.apiUrl;
  Loggedinuserid: any;

  constructor(public navCtrl: NavController, public menu: MenuController, public globalvariable: GlobalProvider, public navParams: NavParams, public formBuilder: FormBuilder, public authenticationService: AuthenticationProvider, public locationInfoService: LocationInfoProvider, public imageUploadService: ImageUploadProvider, public OTPService: OTPProvider, public loadingCtrl: LoadingController, public alertCtrl: AlertController, public database: db, public toastctrl: ToastController) {
   //   console.log('con');
      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      loading.present();
      this.Loggedinuserid = globalvariable.LoggedInUserId;
    //if (navParams.data != '' || navParams.data != undefined) {
    //  this.logoffuser = navParams.data;
    // //this.logoff(this.logoffuser);
    //}
    //this.db.executeSql()
    this.navCtrl = navCtrl;

    //this.authForm = formBuilder.group({
    //  username: ['', Validators.compose([Validators.required, Validators.pattern('[a-zA-Z]*'), Validators.minLength(8), Validators.maxLength(30)])],    
    //});

    this.authForm = formBuilder.group({
      username: ['', Validators.compose([Validators.required])],
      password: ['', Validators.compose([Validators.required])]
    });

    this.regForm = formBuilder.group({
      firstName: ['', Validators.compose([Validators.required])],
      lastName: ['', Validators.compose([Validators.required])],
      //email: ['', Validators.compose([Validators.required])],
      email: ['', Validators.compose([Validators.required]),
        this.isEmailUnique.bind(this) 
      ],
      mobile: ['', Validators.compose([Validators.required]),
        this.ismobileUnique.bind(this)
      ],
      OTP: ['', Validators.compose([Validators.required])],
      gender: [''],
      DOB: ['', Validators.compose([Validators.required])],
      regPassword: ['', Validators.compose([Validators.required])],
      ConfirmPassword: new FormControl('', [Validators.required, this.equalto('regPassword')]),
      country: [''],
      state: [''],
      city: [''],
      hdnImage: [''],
      });
  //    alert("call");
      
      setTimeout(() => {
       
      //  alert("call again");
        this.check();
        loading.dismiss();
      }, 1000);
  }
  ionViewDidEnter() {
    this.menu.swipeEnable(false);
  }
  ionViewWillLeave() {
    this.menu.swipeEnable(true);
  }
  check() {
    this.database.Getpreinserteddata().then(successdb => {
      this.authenticationService.Login(successdb[0].Email, successdb[0].Password).then(success => {
        if (success.IsSuccess == true) {    
          let obh = JSON.parse(success.ResponseData);
          if (obh[0].Id > 0) {
            window.localStorage.setItem('Userid', obh[0].Id);
            window.localStorage.setItem('username', obh[0].EmailId);
            window.localStorage.setItem('password', obh[0].Password);
            var t = window.localStorage.getItem('username');
            window.localStorage.setItem('profile', obh[0].ProfileImage);
            window.localStorage.setItem('name', obh[0].FirstName + " " + obh[0].LastName);
            this.authenticationService.UsersLoginInfo_Insert_Update(window.localStorage.getItem('Userid')).then(success => {
              success => { }
            });
            // UserId, Firstname, Lastname, Profilepic, Coverpic, CoutryId, StateId, CityId, Email, Password 
            this.database.LoginUserDetail(obh[0].Id, obh[0].FirstName, obh[0].LastName, obh[0].ProfileImage, obh[0].CoverImage, obh[0].CountryId, obh[0].StateId, obh[0].CityId, obh[0].EmailId, obh[0].Password).then(Insertedresponse => {
             // alert("Inserted")
            }, error => { /*alert("Not inserted"); */});

            this.navCtrl.setRoot(Home);
          }
        }
      }, error1 => {
      //  alert("Error Login : " + JSON.stringify(error1));
      });
    }, error => {
     // alert("error pre info" + JSON.stringify(error))
    });

}
  isEmailUnique(control: FormControl) {
    return new Promise(resolve => {
      this.authenticationService.isEmailExist(control.value).then((res) => {
        if (res.IsSuccess === true) {
          resolve({ 'isEmailUnique': true });
        }
        else {
          resolve(null);
        }
      }, (err) => {
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

  changeListener($event): void {
    this.file = $event.target.files[0];
   // console.log(this.file);
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.imageUploadService.Upload(this.file).then(success => {
   //   console.log(success);
      this.hdnImageData = success;
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: '"Image uploded successfully"',
        buttons: ['OK']
      });
      alert.present();
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: '"Error in uploading image"',
        buttons: ['OK']
      });
      alert.present();
   //   console.log(error);// Error getting the data

    });

  }

  public ionViewDidLoad() {

    this.getCountriesList();
    this.GetStateListByCountry(101);
    this.GetCityListByState(38);

    setTimeout(() => {
      this.regForm.controls['country'].setValue('101');
      this.regForm.controls['state'].setValue('38');
      this.regForm.controls['city'].setValue('4933');
  //    console.log('state');
    }, 5000);

  }

  public userLogin = {
    username: '',
    password: '',
    firstname: '',
    lastname: ''
  }
  
  public user = {
    DOB: '1990-02-19',
  }

  //firebase.auth().onAuthStateChanged(function(this.Loggedinuserid) {
  //  if (user) {
  //    // User is signed in
  //    // Show them the authenticated content...
  //  }
  //  else {
  //    // No user is signed in
  //    // Let's sign them in
  //   // signUserIn();
  //  }
  //});

  signInSubmit(value: any): void
  {
    console.log(value);
    if (this.authForm.valid) {

      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      //loading.present();
      this.authenticationService.Login(value.username, value.password).then(success => {
        loading.dismiss();
    //    console.log("111" + success.ResponseData);
        if (success.IsSuccess == true)
        {
        //  console.log("detail  :  " + success.ResponseData);
          let obh = JSON.parse(success.ResponseData);
       //   console.log("ddd" + obh[0]);
       //   console.log(obh[0].Id);
          if (obh[0].Id > 0)
          {            
            window.localStorage.setItem('Userid', obh[0].Id);
            window.localStorage.setItem('username', value.username);
            window.localStorage.setItem('password', value.password);
            var t = window.localStorage.getItem('username');
            window.localStorage.setItem('profile', obh[0].ProfileImage);
            window.localStorage.setItem('name', obh[0].FirstName + " " + obh[0].LastName);           
            this.authenticationService.UsersLoginInfo_Insert_Update(window.localStorage.getItem('Userid')).then(success => {
              success => { }
            });
            // UserId, Firstname, Lastname, Profilepic, Coverpic, CoutryId, StateId, CityId, Email, Password 
            this.database.LoginUserDetail(obh[0].Id, obh[0].FirstName, obh[0].LastName, obh[0].ProfileImage, obh[0].CoverImage, obh[0].CountryId, obh[0].StateId, obh[0].CityId, obh[0].EmailId, obh[0].Password).then(Insertedresponse => {
           //   alert("Inserted")
            }, error => { /*alert("Not inserted");*/ });
            this.navCtrl.setRoot(Home);
          }
        }
        else {
          let alert = this.alertCtrl.create({
            title: '"Invalid User Name or Password"',
            buttons: ['OK']
          });
          alert.present();
        }
      }, (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: 'Invalid Login',
          //subTitle: error,
          buttons: ['OK']
        });
        alert.present();
     //   console.log(error);
      });
    }
  }

  countrySelect() {
  }

  countrySelected(e) {
    this.GetStateListByCountry(e)
    this.GetCityListByState(0)
  }

  stateSelected(e) {
    this.GetCityListByState(e)
  }

  getCountriesList() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.locationInfoService.GetCountries().then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.CountryList = JSON.parse(success.ResponseData);
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

  GetStateListByCountry(e) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.locationInfoService.GetStatesByCountry(e).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.StateList = JSON.parse(success.ResponseData);
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

  GetCityListByState(e) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.locationInfoService.GetCitiesByState(e).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.CityList = JSON.parse(success.ResponseData);
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

  registerSubmit(value: any): void {
  //  console.log(value);
    if (this.regForm.valid) {
  //    console.log(value);
      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      var student = {
        FirstName: value.firstName,
        LastName: value.lastName,
        StudentName: value.firstName + " " + value.lastName,
        Country: value.country,
        state: value.state,
        MobileNumber: value.mobile,
        Password: value.regPassword,
        EmailId: value.email,
        City: value.city,
        DOB: value.DOB,
        Gender: value.gender,
        Picture:value.hdnImage,
      };
      var jsonStudentData = JSON.stringify(student);
      loading.present();
      this.authenticationService.Register(jsonStudentData).then(success => {
        loading.dismiss();
        if (success.IsSuccess === true) {
          this.authenticationService.Login(value.email, value.regPassword).then(success => {
            if (success.ResponseData.length > 0) {
              window.localStorage.setItem('username', value.email);
              window.localStorage.setItem('password', value.regPassword);
              var t = window.localStorage.getItem('username');
              let toast = this.toastctrl.create({
                message: 'User was added successfully',
                duration: 3000,
                position: 'bottom'
              });
              toast.present();
              this.navCtrl.setRoot(Home);
              let obh = JSON.parse(success.ResponseData);
              window.localStorage.setItem('profile', obh[0].ProfileImage);
              window.localStorage.setItem('name', obh[0].FirstName + " " + obh[0].LastName);
              window.localStorage.setItem('Userid', obh[0].Id);
              this.database.LoginUserDetail(obh[0].Id, obh[0].FirstName, obh[0].LastName, obh[0].ProfileImage, obh[0].CoverImage, obh[0].CountryId, obh[0].StateId, obh[0].CityId, obh[0].EmailId, obh[0].Password).then(Insertedresponse => {
           //     alert("Inserted")
              }, error => { /*alert("Not inserted");*/ });

            }
            else {
              let alert = this.alertCtrl.create({
                title: '"Invalid User Name or Password"',
                buttons: ['OK']
              });
              alert.present();
            }
          });
        }
        else {
          let alert = this.alertCtrl.create({
            title: '"Invalid User Name or Password"',
            buttons: ['OK']
          });
        }
    //    console.log(success);
      }, (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: 'Invalid Login',
          //subTitle: error,
          buttons: ['OK']
        });
        alert.present();
       // console.log(error);// Error getting the data   
      });
    }
  }

  ForgottenPassword(event: Event) {
    event.stopPropagation();

    alert('Forgotten password... coming soon...');
  }

  sendOTP() {
    this.txtSendOTP = "Resend OTP";
    this.send = false;
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let mobileNumber = this.regForm.controls['mobile'].value;
 //   console.log(mobileNumber);
    this.OTPService.SendOTP(mobileNumber).then(success => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'OTP Send',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
 //     console.log(success);
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
   //   console.log(error);// Error getting the data   
    });
  }

  verifyOTP() {
    this.verify = false;
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let OTP = this.regForm.controls['OTP'].value;
  //  console.log(OTP);
    this.OTPService.VerifyOTP(OTP).then(success => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Mobile Number varified',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
      this.verify = true;
     // console.log(success);
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
   //   console.log(error);// Error getting the data   
    });
  }

  openForgotPop() {
    let self = this;
    let prompt = this.alertCtrl.create({
      title: "Reset Password",
      message: "Please enter your Email to reset your Password.",
      cssClass: 'alert-Custom',
      inputs: [
        {
          name: "email",
          placeholder: "Email"
        },
      ],
      buttons: [
        {
          text: "Cancel",
          handler: data => {
          //  console.log("Cancel");
          }
        },
        {
          text: "Forgot",
          handler: data => {
            self.forgotPassword(data.email);
          }
        }
      ]
    });
    prompt.present();
  };

  forgotPassword(email) {
    this.verify = false;
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
 //   console.log(email);
    this.authenticationService.ForgotPassword(email).then(success => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: success.Message,
        buttons: ['OK']
      });
      alert.present();
   //   console.log(success);
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        buttons: ['OK']
      });
      alert.present();
   //   console.log(error);// Error getting the data   
    });
  }
  
  FAQ(event: Event) {
    this.navCtrl.push(PaypalPage);
  }
}
