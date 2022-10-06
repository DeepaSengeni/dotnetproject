import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { PayPal, PayPalPayment, PayPalConfiguration } from 'ionic-native';
import { PayPalpay } from '../../providers/PaypalPayment/PayPal';
import { InAppBrowser } from 'ionic-native';
import { Jsonp } from '@angular/http';
/*
  Generated class for the paypal page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
declare var window: any;
@Component({
  selector: 'page-paypal',
  templateUrl: 'paypal.html'
})


export class PaypalPage {

  Token: any;

  constructor(public PayPalservice: PayPalpay) { }
  payment: PayPalPayment = new PayPalPayment('10.10', 'USD', 'TV', 'sale');
  currencies = ['EUR', 'USD'];
  payPalEnvironment: string = 'payPalEnvironmentSandbox';

  makePayment() {
    PayPal.init({
      // PayPalEnvironmentProduction: Config.payPalEnvironmentProduction,
      // PayPalEnvironmentSandbox: Config.payPalEnvironmentSandbox
      PayPalEnvironmentSandbox: 'AR1h6IUOGH0Mw3fDMiR4xZABqSXN8dzLs06PeL7jMBgpqXEda3LXc7kqO3srKeZsq89OJgHOleNWzRpa',
      PayPalEnvironmentProduction: ''
    }).then((firstfun) => {
      alert("First  : " + JSON.stringify(firstfun));

      PayPal.prepareToRender(this.payPalEnvironment, new PayPalConfiguration({})).then((nextfun) => {

        alert("Second  : " + JSON.stringify(nextfun));

        PayPal.renderSinglePaymentUI(this.payment).then((response) => {

          alert('Successfully paid. Status = ' + response.response.state);
          alert(JSON.stringify(response));

        }, (error3) => {
          alert("error3 : " + JSON.stringify(error3));
          alert('Error or render dialog closed without being successful');
        });
      }, (error2) => {
        alert("error2 : " + JSON.stringify(error2));
        alert('Error in configuration');
      });
    }, (error1) => {
      alert("error1 : " + JSON.stringify(error1));
      alert('Error in initialization, maybe PayPal isn\'t supported or something else');
    });
  }

  //GetToken() {
  //  this.PayPalservice.GetToken().then(success => {
  //    let successdata = JSON.parse(success);
  //    this.Token = successdata.access_token;
  //    this.PayPalservice.getpayment(this.Token).then(redirecturl => {
  //             this.InappBrowser(redirecturl.links[1].href);
  //    }, error => {
  //           alert(JSON.stringify(error));
  //    });
  //  },
  //    eorr => { alert(JSON.stringify(eorr)); });
  //}

  InappBrowser(url) {
    var browserRef = window.cordova.InAppBrowser.open(url, "_blank", "location=no,clearsessioncache=yes,clearcache=yes");
    browserRef.addEventListener("loadstart", (event) => {
       if ((event.url).indexOf("http://localhost/callback") === 0) {
         var parsedResponse = {};
         var split1 = (event.url).split('&')[2];
         var pa = (event.url).split('&')[3];
         var payerId = pa.split('=')[1];
         var temp = JSON.stringify(split1.split('=')[1]);
         var payment = temp.split('?')[0];
         var paymentId = payment.split('"')[1];
         var to = (event.url).split('?')[1];
         var too = to.split('=')[1];
         var token = too.split('&')[0];
         this.PayPalservice.GetToken().then(success => {
           let successdata = JSON.parse(success);
           this.Token = successdata.access_token;
           this.PayPalservice.ExecutePayment(this.Token, paymentId, payerId).then(success => { alert("Inside If  :" + JSON.stringify(success)) }, error => { alert("Inside else  :" + JSON.stringify(error)) })
         });
       }
     }, error => { alert("Inside else : "+JSON.stringify(error)); });
    browserRef.addEventListener("exit", function (event) {
      alert(JSON.stringify(event));
    }, error1 => { alert("error1 portion"+JSON.stringify(error1)); });

  }


 








}
