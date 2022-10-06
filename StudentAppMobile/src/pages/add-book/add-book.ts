import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-add-book',
  templateUrl: 'add-book.html'
})
export class AddBook {

  searchQuery: string = '';
  items: string[];





  countryOpts: { title: string, subTitle: string };
  stateOpts: { title: string, subTitle: string };
  cityOpts: { title: string, subTitle: string };

  constructor(public navCtrl: NavController) {

    this.initializeItems();

    this.countryOpts = {
      title: 'Country',
      subTitle: 'Select your country'
    };
    this.stateOpts = {
      title: 'State',
      subTitle: 'Select your country'
    };
    this.cityOpts = {
      title: 'City',
      subTitle: 'Select your country'
    };
  }

  initializeItems() {
    this.items = [
      'Amsterdam',
      'Bogota'     
    ];
  }

  getItems(ev: any) {
    // Reset items back to all of the items
    this.initializeItems();

    // set val to the value of the searchbar
    const val = ev.target.value;

    // if the value is an empty string don't filter the items
    if (val && val.trim() != '') {
      this.items = this.items.filter((item) => {
        return (item.toLowerCase().indexOf(val.toLowerCase()) > -1);
      })
    }
  }

  public userLogin = {

  }

  public user = {
    DOB: '1990-02-19',
  }

  countrySelect() {
    console.log('country selected');
  }

  login(event: Event) {
    event.stopPropagation();

    alert('login...  coming soon..');
  }


  register(event: Event) {
    event.stopPropagation();

    alert('register...  coming soon..');
  }

  create(event:Event) {
    event.stopPropagation();

    alert('Create Account...  coming soon...');
  }

  ForgottenPassword(event: Event) {
    event.stopPropagation();

    alert('Forgotten password... coming soon...');
  }


  FAQ(event: Event) {
    event.stopPropagation();

    alert('FAQ Coming soon...');
  }
  //showAlert() {
  //  const alert = this.navCtrl.create({
  //    title: 'New Friend!',
  //    subTitle: 'Your friend, Obi wan Kenobi, just accepted your friend request!',
  //    buttons: ['OK']
  //  });
  //  alert.present();
  //}

}
