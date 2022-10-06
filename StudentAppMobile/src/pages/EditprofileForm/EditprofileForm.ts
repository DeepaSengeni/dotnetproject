import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController, ToastController } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators, ValidatorFn, AbstractControl, FormControl } from '@angular/forms';
import { AuthenticationProvider } from '../../providers/authentication/authentication';
import { LocationInfoProvider } from '../../providers/location-info/location-info';
import { UsersInfoProvider } from '../../providers/Users/UsersInfo';
import { Home } from '../home/home';


/*
  Generated class for the EditprofileForm page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
  selector: 'page-EditprofileForm',
  templateUrl: 'EditprofileForm.html'
})
export class EditprofileForm {

  profileForm: FormGroup;
  CountryList: any;
  StateList: any;
  CityList: any;
  id = 0;
  datalistdata: any[];
  data: string[];
  constructor(public navCtrl: NavController, public toastctrl: ToastController, public UserinfoService: UsersInfoProvider, public alertCtrl: AlertController, public loadingCtrl: LoadingController, public navParams: NavParams, public formBuilder: FormBuilder, public authenticationService: AuthenticationProvider, public locationInfoService: LocationInfoProvider) {

    this.navCtrl = navCtrl;
    this.id = navParams.get('id');
    //alert(this.id);
    this.GetProfile(this.id);
    this.getCountriesList();
    this.profileForm = formBuilder.group({
      firstName: ['', Validators.compose([Validators.required])],
      lastName: ['', Validators.compose([Validators.required])],
      gender: [''],
      DOB: ['', Validators.compose([Validators.required])],
      country: [''],
      state: [''],
      city: [''],
    });
  }

  ionViewDidLoad() {
 //   console.log('ionViewDidLoad EditprofileFormPage');
  }

  GetProfile(id) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let e;
    if (id === 0 || id === undefined)
    {
      e = window.localStorage.getItem('Userid');
    }
    else {
      e = id;
    }
    this.UserinfoService.GetUserInfo(e).then(success =>
    {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
        this.datalistdata = this.data;
      //  console.log(this.datalistdata);
        this.profileForm.setValue({
          firstName: this.datalistdata[0].FirstName,
          lastName: this.datalistdata[0].LastName,
          gender: this.datalistdata[0].Gender,
          DOB: this.datalistdata[0].DOB,
          country: this.datalistdata[0].CountryId,
          state: this.datalistdata[0].StateId,
          city: this.datalistdata[0].CityId,
        });
     
      }
    },
      (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: 'Service Error',
          subTitle: error,
          buttons: ['Continue']
        });
        alert.present();
      });
  }

  countrySelect()
  {
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
  
  profileSubmit(value: any): void {
   // console.log(value);
    if (this.profileForm.valid) {
    //  console.log(value);
      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      var profile = {
        Id:this.id,
        StudentName: value.firstName + " " + value.lastName,
        FirstName: value.firstName,
        LastName: value.lastName,
        CountryId: value.country,
        StateId: value.state,
        DOB: value.DOB,
       // MobileNumber: value.mobile,
      //  Password: value.regPassword,
      //  EmailId: value.email,

        CityId: value.city,
        Gender: value.gender,
      //  Picture: value.hdnImage,
      };
      var jsonStudentData = JSON.stringify(profile);
      //loading.present();
      this.authenticationService.Editprofile(jsonStudentData).then(success => {
        loading.dismiss();
        if (success.IsSuccess === true) {
          let toast = this.toastctrl.create({
            message: 'Profile updated successfully',
            duration: 2000,
            position: 'top'
          });
          toast.present();
          this.navCtrl.setRoot(Home);
        }
        else {
          let alert = this.alertCtrl.create({
            title: '"Failed to Update Profile "',
            buttons: ['OK']
          });
        }
     //   console.log(success);
      }, (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: 'Profile Updation Fail..',
          //subTitle: error,
          buttons: ['OK']
        });
        alert.present();
      //  console.log(error);// Error getting the data   
      });

    }

  }

}
