import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

declare var MathEditor: any;


@Component({
    selector: 'page-Imagesavepopup',
    templateUrl: 'Imagesavepopup.html'
})
export class ImagesavepopupPage {

  constructor(public navCtrl: NavController) { }

  ionViewDidLoad()
    {
    //console.log('ionViewDidLoad ImagesavepopupPage');
    //var myEditor = new MathEditor('demo');
    //myEditor.buttons = ["fraction", "square_root", "cube_root", "root", 'superscript', 'subscript', 'multiplication', 'division', 'plus_minus', 'pi', 'degree', 'not_equal', 'greater_equal', 'less_equal', 'greater_than', 'less_than', 'angle', 'parallel_to', 'perpendicular', 'triangle', 'parallelogram'];["fraction", "square_root", "cube_root", "root", 'superscript', 'subscript', 'multiplication', 'division', 'plus_minus', 'pi', 'degree', 'not_equal', 'greater_equal', 'less_equal', 'greater_than', 'less_than', 'angle', 'parallel_to', 'perpendicular', 'triangle', 'parallelogram'];
    //myEditor.setTemplate('floating-toolbar');
    }
}
