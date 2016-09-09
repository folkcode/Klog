import { Component, OnInit } from '@angular/core';
import { PostsService } from './posts.service';
import { WaitComponent } from '../shared/wait/wait.component';
import * as animate from "CommonAnimations";

@Component({
    selector: 'posts-component', 
    templateUrl: 'app/posts/posts.component.html',
    providers: [PostsService],
    directives: [WaitComponent]
})

export class PostsComponent implements OnInit {
    isBusy: boolean = true;
  
    constructor(private _postService: PostsService) {    
    }
    
    posts: any;
    errorMessage: string;
    
    ngOnInit() {
        this._postService.getPosts(3)
            .subscribe(
            data => this.posts = data,
            error => this.errorMessage = error,
            () => {
                this.isBusy = false;
               // setTimeout(() => { animate.fadeIn(".post-box-cnt"); }, 2000)    
            }
            );
    }

    fadeInPosts() {
        console.log('ieksh hey');
        return animate.fadeInOut('.post-box-cnt', 2, 1);
    }
}
