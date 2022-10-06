import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController } from 'ionic-angular';
import { ViewController } from 'ionic-angular';

import { LocationInfoProvider } from '../../providers/location-info/location-info';

/*
  Generated class for the SampleModalPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-SampleModalPage',
    templateUrl: 'SampleModalPage.html'
})
export class SampleModalPagePage {

  CountryList: any;
  StateList: any;
  CityList: any;
  SubjectList: any;

  constructor(public navCtrl: NavController, public navParams: NavParams, public viewCtrl: ViewController, public locationInfoService: LocationInfoProvider, public loadingCtrl: LoadingController, public alertCtrl: AlertController)
  {

  }
    ionViewDidLoad() {
      console.log('ionViewDidLoad SampleModalPagePage');
      this.getCountriesList();
      this.GetStateListByCountry(98);
      this.GetCityListByState(2338);
      this.GetSubjectList();
    }
 
  closeModal() {
    this.viewCtrl.dismiss();
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

  GetSubjectList() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.locationInfoService.GetallSubjectlist().then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.SubjectList = JSON.parse(success.ResponseData);
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


}
