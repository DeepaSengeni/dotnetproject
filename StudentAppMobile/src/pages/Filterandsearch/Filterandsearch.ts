import { Component } from '@angular/core';
import { NavController, NavParams, AlertController, LoadingController } from 'ionic-angular';
import { LocationInfoProvider } from '../../providers/location-info/location-info';
import { NotebookProvider } from '../../providers/Notebook/Notebook';
import { NotebookDetailsPage } from '../NotebookDetails/NotebookDetails';
import { NotebookPageDetailsPage } from '../NotebookPageDetails/NotebookPageDetails';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { config } from '../../app/config';



/*
  Generated class for the Filterandsearch page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-Filterandsearch',
    templateUrl: 'Filterandsearch.html'
})
export class Filterandsearch {
  authForm: FormGroup;
  password: string;
  CountryList: any;
  bookLists: any = [];
  StateList: any;
  CityList: any;
  SubjectList: any;
  Notebooklist: any;
  CountryId: any;
  StateId: any;
  CityId: any;
  SubjectId: any;
  url = config.apiUrl;

  constructor(public navCtrl: NavController, public navParams: NavParams, public alertCtrl: AlertController, public loadingCtrl: LoadingController, public locationInfoService: LocationInfoProvider, public NotebooksService: NotebookProvider) {
    this.CountryId = 0;
    this.StateId = 0;
    this.CityId = 0;
    this.getCountriesList();
    this.GetSubjectList();

  }
    ionViewDidLoad() {
     //   console.log('ionViewDidLoad FilterandsearchPage');
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

  countrySelected()
  {
    this.GetStateListByCountry(this.CountryId);
    if (this.CountryId == 0)
    {
      this.StateId = 0;
      this.CityId = 0;
    }
  }

  stateSelected()
  {
   // alert(this.StateId);
    this.GetCityListByState(this.StateId);
  }

  citySelected()
  {
   // alert(this.CityId);
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
        // console.log(this.SubjectList);
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

  sujectSelected()
  {
  //  alert(this.SubjectId);
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.NotebooksService.NoteBookLoadBySubjectId(this.SubjectId).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.Notebooklist = JSON.parse(success.ResponseData);
        //console.log(this.Notebooklist);
        for (let i = 0; i < this.Notebooklist.length; i++) {
          this.bookLists.push(this.Notebooklist[i]);
        }
       // console.log(this.bookLists);
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

  home(values: any) {
    this.navCtrl.push(NotebookDetailsPage, { id: values });
  }

  notebookdetail(value: any): void {
    // let notebook = this.modalCtrl.create(NotebookPageDetailsPage, { idd: value });
    this.navCtrl.push(NotebookPageDetailsPage, { id: value });
    //notebook.present();

  }

  Search(values: any)
  {
    if (this.authForm.valid) {
     // console.log(values);
     // console.log(":::"+values.booksearch);
    }
  }

  logForm() {

   // console.log(this.password);
  //  alert(this.password);

  }

  getItems(ev: any) {
     const val = ev.target.value;
    //alert(val);
    if (val !== "") {
      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      //loading.present();
      this.NotebooksService.SearchNoteBookByName(val, this.CountryId, this.StateId, this.CityId).then(success => {
        loading.dismiss();
        if (success.ResponseData.length > 0) {
          this.Notebooklist = JSON.parse(success.ResponseData);
        //  console.log(this.Notebooklist);
          for (let i = 0; i < this.Notebooklist.length; i++) {
            this.bookLists.push(this.Notebooklist[i]);
          }
         // console.log(this.bookLists);
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
    else {
      //console.log("No Record");
      this.bookLists = [];
    }
    }

}
