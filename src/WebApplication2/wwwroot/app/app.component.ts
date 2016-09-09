import { Component } from '@angular/core';

import {CvComponent} from './cv/cv.component';
import {HomeComponent} from './home/home.component';
import {PostsComponent} from './posts/posts.component';
import {DemosComponent} from './demos/demos.component';
import {FooterComponent} from './shared/footer/footer.component';
import {NavComponent} from './shared/nav/nav.component';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    directives: [HomeComponent, PostsComponent, DemosComponent, CvComponent, FooterComponent, NavComponent] 
})
export class AppComponent {
}
