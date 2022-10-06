import { Component } from '@angular/core';
import { NavController, NavParams, ViewController, LoadingController, AlertController, ToastController } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators, ValidatorFn, AbstractControl, FormControl } from '@angular/forms';
import { PayPalpay } from '../../providers/PaypalPayment/PayPal';
import { InAppBrowser } from 'ionic-native';
import { LocationInfoProvider } from '../../providers/location-info/location-info';
import { CommonProvider } from '../../providers/Common/common';
import { AdvertisementProvider } from '../../providers/Advertisement/Advertisement';
import { GlobalProvider } from '../../providers/globalvariable/GlobalUserId';
import { global } from '@angular/core/src/facade/lang';
import { Home } from '../home/home';
declare var window: any;
@Component({
  selector: 'page-AdCreateForm',
  templateUrl: 'AdCreateForm.html'
})
export class AdCreateForm {

  AdForm: FormGroup;
  Token: any;
  CountryList: any;
  StateList: any;
  CityList: any;
  SubjectList: any;
  Sdate: string;
  checkstartdate: string;
  checkenddate: string;20
  Edate: string;
  ans: any;
  dropdt: any;
  pickdt: any;
  cityIdlist: any;
  cityPricelist: any;
  total: any;
  availabiltyresponse: any;
  responsemessage: any;
  userid: any;
  currencydata: any;
  totalamount: any;
  file: File;
  filelist: any = [];
  hdnImageData: any;
  pageType: any;
  city_Id: any;
  SelectedPrice: any;
  Successdata: any;
  countrydata: any;
  CurrentUserCountryISOcode: any;
  CurrentUserCountryCurrencySymbol: any;
  CountryISOCode: any;
  CountryCurrencySymbole: any;
  FinalConvertedAmount: any;
  Headline: any;
  AdId: any;
  date: string = new Date().toLocaleDateString();

  constructor(public navCtrl: NavController, public toastctrl: ToastController, public GlobalService: GlobalProvider, public PayPalservice: PayPalpay, public formBuilder: FormBuilder, public navParams: NavParams, public viewCtrl: ViewController, public locationInfoService: LocationInfoProvider, public loadingCtrl: LoadingController, public alertCtrl: AlertController, public CommonServiceProvider: CommonProvider, public AdvertisementServiceProvider: AdvertisementProvider) {

    this.AdForm = formBuilder.group({
      headline: ['', Validators.compose([Validators.required])],
      features: ['', Validators.compose([Validators.required])],
      description: ['', Validators.compose([Validators.required])],
      email: ['', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])],
      mobile: ['', Validators.compose([Validators.required,
        Validators.maxLength(10),
        Validators.minLength(10)])],
      product: ['', Validators.compose([Validators.required])],
      web: ['', Validators.compose([Validators.required,
      Validators.pattern('[\\w_-]+(?:\\.[\\w_-]+)+([\\w.,@?^=%&:/~+#-]*[\\w@?^=%&/~+#-])?')])],
      country: [''],
      state: [''],
      city_Id: [''],
      hdnImage: [''],
      Typepage: ['SinglePic'],
      startdate: ['', Validators.compose([Validators.required])],
      enddate: ['', Validators.compose([Validators.required])],
    });


    this.GetUserCountryDetail();
    this.availabiltyresponse = 0;
    this.cityIdlist = '';
    this.cityPricelist = '';
    this.total = 0;
    this.userid = 0;
    this.ans = 0;
    this.AdId = 0;
    this.totalamount = 0;
    this.pageType = 'SinglePic';
    this.getCountriesList();
    this.GetStateListByCountry(101);
    this.GetCityListByState(38);
    this.city_Id = [''];
    this.SelectedPrice = [''];
    this.countrySelect();
  }
  
  ionViewDidLoad() {
 //   console.log('ionViewDidLoad AdCreateFormPage');
  }

  countrySelect() {
  }

  countrySelected(e) {
    this.selectedcountrydata(e);
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

  setPageType() { }

  startdate(event) {
    this.Sdate = event.month.value + "/" + event.day.value + "/" + event.year.value;
    this.checkstartdate = event.day.value + "/" + event.month.value + "/" + event.year.value;
  }

  enddate(event) {
    this.Edate = event.month.value + "/" + event.day.value + "/" + event.year.value;
    this.checkenddate = event.day.value + "/" + event.month.value + "/" + event.year.value;
  //  console.log("start date " + this.checkstartdate + ", End date " + this.checkenddate);
    this.dropdt = new Date(this.Sdate);
    this.pickdt = new Date(this.Edate);
    this.ans = ((this.pickdt - this.dropdt) / (24 * 3600 * 1000));
    this.totalamount = (this.total * this.ans).toFixed(2);
  }

  cityChecked()
  {
    this.total = 0;
  var datacity = this.city_Id;
  for (var i = 0; i < datacity.length;i++)
  {
    var city = datacity[i];
    let term = this.CityList.filter(p => p['ID'] == city);
    this.total = this.total + (parseInt(term[0]['Price']) * this.FinalConvertedAmount);
    }
    this.totalamount = (this.total * this.ans).toFixed(2);
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
        this.currencydata = JSON.parse(success.ResponseData);
        this.CurrentUserCountryISOcode = this.currencydata[0].code;
        this.CurrentUserCountryCurrencySymbol = this.currencydata[0].currency_symbole;
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

  CheckAvailability() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.CommonServiceProvider.CheckCityAvailability(this.city_Id, this.checkstartdate, this.checkenddate).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.availabiltyresponse = JSON.parse(success.ResponseData);
        if (this.availabiltyresponse[0].Column1 == 1) {
          this.responsemessage = "Sorry! This combination of the cities are not available with these dates.";
        }
        else {
          this.responsemessage = "Congratulations! You have got space for Advertisement.";
        }
      }
   //   console.log(this.availabiltyresponse[0].Column1);
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
  }

  changeListener($event): void {
    this.file = $event.target.files[0];
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.userid = window.localStorage.getItem('Userid');
    this.AdvertisementServiceProvider.Upload(this.file, this.userid).then(success => {
   //   console.log(success);
      this.hdnImageData = success;
      loading.dismiss();
     // let alert = this.alertCtrl.create({
     //   title: '"File uploded successfully"',
     //   buttons: ['OK']
     // });
     // alert.present();
    },
      (error) => {
        loading.dismiss();
        let alert = this.alertCtrl.create({
          title: '"Error in uploading File"',
          buttons: ['OK']
        });
        alert.present();
    //    console.log(error);

      });

  }

  Multiplefiles($event): void {
    this.hdnImageData = "";
    var files = $event.target.files;
    this.userid = window.localStorage.getItem('Userid');
    if (files.length > 1) {
      for (var i = 0; i < files.length; i++) {
        var f = files[i];
        this.AdvertisementServiceProvider.Upload(f, this.userid).then(success => {
          this.hdnImageData = this.hdnImageData + "," + success;
        },
          (error) => {
            let alert = this.alertCtrl.create({
              title: '"Error in uploading image"',
              buttons: ['OK']
            });
            alert.present();
          //  console.log(error);

          });
      }
   
    }

  }

  CreateAd(value: any): void
  {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    loading.present();
    var imguploadtype = 0;
    if (this.pageType == 'SinglePic') { imguploadtype = 1 } else if (this.pageType == 'MultiplePic') { imguploadtype = 2 } else if (this.pageType == 'AudioFile') { imguploadtype = 4 } else if (this.pageType == 'AudioFile') { imguploadtype = 3 }
    this.CommonServiceProvider.CheckCityAvailability(this.city_Id, this.checkstartdate, this.checkenddate).then(success => {
      if (success.ResponseData.length > 0) {
        this.availabiltyresponse = JSON.parse(success.ResponseData);
        loading.dismiss();
        if (this.availabiltyresponse[0].Column1 == 1) {
          this.responsemessage = "Sorry! This combination of the cities are not available with these dates.";
        }
        else {
          //this.responsemessage = "Congratulations! You have got space for Advertisement.";
          if (this.AdForm.valid) {
            this.Headline = value.headline;
            var UserId = this.GlobalService.LoggedInUserId;
            var AdData = {
              uploadtype: imguploadtype,
              headline: value.headline,
              Features: value.features,
              description: value.description,
              AdvertiserEmialId: value.email,
              AdvertiserMobileNumber: value.mobile,
              Password: value.product,
              urladdress: value.web,
              Country: value.country,
              state: value.state,
              startdate: value.startdate,
              enddate: value.enddate,
            };
            var jsonStudentData = JSON.stringify(AdData);
         //   loading.present();
            this.AdvertisementServiceProvider.CreateAd(AdData, this.city_Id, this.hdnImageData, UserId).then(success => {
              if (success.ResponseData.length > 0) {
                this.AdId = parseInt(success.Message);
                this.Successdata = JSON.parse(success.ResponseData);
                this.GetToken();
                loading.dismiss();
              }
              else {
                loading.dismiss();
                let alert = this.alertCtrl.create({
                  title: '"Ad creation fail"',
                  buttons: ['OK']
                });
              }
          //    console.log(success);
            }, (error) => {
              loading.dismiss();
              let alert = this.alertCtrl.create({
                title: 'Fail',
                buttons: ['OK']
              });
              alert.present();
            //  console.log(error);  
            });
          }
        }
      }
//      console.log(this.availabiltyresponse[0].Column1);
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
 


  }

  selectedcountrydata(id)
  {
    this.AdvertisementServiceProvider.selectedcountry(id).then(success => {
      this.countrydata = JSON.parse(success.ResponseData);
        this.CountryISOCode = this.countrydata[0].code;
        this.CountryCurrencySymbole = this.countrydata[0].currency_symbole;
        this.AdvertisementServiceProvider.GetCurrentCountryCurrencyRate(this.CurrentUserCountryISOcode, this.CountryISOCode).then(Positiveres => {
         let Convertedamount = parseFloat(Positiveres[this.CountryISOCode + "_" + this.CurrentUserCountryISOcode].val);
         this.FinalConvertedAmount = Convertedamount.toFixed(2);

        }, error => {/* alert(JSON.stringify(error))*/ });
   //   }
    }, error => {
    //  alert(JSON.stringify(error));
      });
  }

  GetToken() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    loading.present();
    //this.totalamount = "20";
    //this.CurrentUserCountryISOcode = "USD";
    this.PayPalservice.GetToken().then(success => {
      let successdata = JSON.parse(success);
      this.Token = successdata.access_token;
      this.PayPalservice.getpayment(this.Token, this.totalamount, this.CurrentUserCountryISOcode).then(redirecturl => {
        this.InappBrowser(redirecturl.links[1].href);
      }, error => {
        loading.dismiss();
   //     alert(JSON.stringify(error));
      });
    },
      eorr => {
        loading.dismiss();
      //  alert(JSON.stringify(eorr));
      });
  }

  InappBrowser(url) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    var browserRef = window.cordova.InAppBrowser.open(url, "_blank", "location=no,clearsessioncache=yes,clearcache=yes");
    browserRef.addEventListener("loadstart", (event) => {
      if ((event.url).indexOf("http://localhost/callback") === 0) {
        var parsedResponse = {};
        var split1 = (event.url).split('&')[1];
        var token = split1.split('=')[1];
        var split2 = (event.url).split('&')[2];
        var payerId = split2.split('=')[1];
        var split3 = event.url.split('?')[1];
        var payment = split3.split('&')[0];
        var paymentId = payment.split('=')[1];
        this.PayPalservice.GetToken().then(success => {
          let successdata = JSON.parse(success);
          this.Token = successdata.access_token;
          this.PayPalservice.ExecutePayment(this.Token, paymentId, payerId).then(success => {
            var Email = window.localStorage.getItem('username');
            var name = window.localStorage.getItem('name');
            var paymentId = success.id;
            var intent = success.intent;
            var state = success.state;
            var inside_Payer = success.payer.payer_info.payer_id;
            var amount = success.transactions[0].amount.total;
            var currency = success.transactions[0].amount.currency;
            this.AdvertisementServiceProvider.PaymentSuccess(Email, name, this.userid, this.Headline, this.AdId, paymentId, currency, amount, inside_Payer, intent, state, this.city_Id).then(onsuccess => {
              let data = [];
              data = onsuccess.ResponseData;
              this.AdvertisementServiceProvider.AdBulkSmsSend_ForAd(this.AdId, this.userid, this.Headline, this.city_Id).then(success => {
            //    alert(JSON.stringify(success))
                browserRef.close();
                this.navCtrl.setRoot(Home);
                let toast = this.toastctrl.create({
                  message: 'Your Add successfully created',
                  duration: 1000,
                  position: 'middle'
                });
                toast.present();
              }, error => {
             //   alert(JSON.stringify(error))
              });
            }, error => {
              alert(JSON.stringify(error));
            });
          }, error => {
         //   alert("Inside else  :" + JSON.stringify(error))
          })
        });
      }
      else
      {
        if ((event.url).indexOf("http://localhost/&Cancel=true") === 0) {
          var returntoken = (event.url).split('=')[2];
          this.AdvertisementServiceProvider.Paymentfail(this.AdId, returntoken).then(() => { });
          browserRef.close();
          loading.dismiss();
          let alert = this.alertCtrl.create({
            title: 'Payment Failed',
            buttons: ['OK']
          });
          alert.present();
        }
        
      }
    }, error =>
      {
        loading.dismiss(); /*alert("Inside else : " + JSON.stringify(error))*/;
      });
    browserRef.addEventListener("exit", function (event)
    {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Add created Successfully',
        buttons: ['OK']
      });
      alert.present();
    }, error1 => {
      loading.dismiss();
   //   alert("error1 portion" + JSON.stringify(error1));
    });
  }

}
