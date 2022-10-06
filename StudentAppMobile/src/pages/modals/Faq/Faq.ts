import { Component } from '@angular/core';
import { NavController, NavParams, ViewController, Platform } from 'ionic-angular';
import { Home } from '../../home/home';

@Component({
    selector: 'page-Faq',
    templateUrl: 'Faq.html'
})
export class FaqPage {

  constructor(public navCtrl: NavController, public navParams: NavParams, public viewctrl: ViewController) { }

    ionViewDidLoad() {

      var accItem = document.getElementsByClassName('accordionItem');
      var accHD = document.getElementsByClassName('accordionItemHeading');
      for (let i = 0; i < accHD.length; i++) {
        accHD[i].addEventListener('click', toggleItem, false);
      }
      function toggleItem() {
        var itemClass = this.parentNode.className;
        for (let i = 0; i < accItem.length; i++) {
          accItem[i].className = 'accordionItem close';
        }
        if (itemClass == 'accordionItem close') {
          this.parentNode.className = 'accordionItem open';
        }
      }
    }
  dismiss()
  {
    this.navCtrl.setRoot(Home);
    this.navCtrl.pop();
  }


}
