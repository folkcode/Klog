/// <reference path="../animation/main.d.ts" />
import { bootstrap }    from '@angular/platform-browser-dynamic';
import { AppComponent } from './app.component';
import { PostsService} from './posts/posts.service';
import { HTTP_PROVIDERS} from '@angular/http';

bootstrap(AppComponent, [HTTP_PROVIDERS, PostsService]);
