"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var posts_service_1 = require('./posts.service');
var wait_component_1 = require('../shared/wait/wait.component');
var animate = require("CommonAnimations");
var PostsComponent = (function () {
    function PostsComponent(_postService) {
        this._postService = _postService;
        this.isBusy = true;
    }
    PostsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._postService.getPosts(3)
            .subscribe(function (data) { return _this.posts = data; }, function (error) { return _this.errorMessage = error; }, function () {
            _this.isBusy = false;
            // setTimeout(() => { animate.fadeIn(".post-box-cnt"); }, 2000)    
        });
    };
    PostsComponent.prototype.fadeInPosts = function () {
        console.log('ieksh hey');
        return animate.fadeInOut('.post-box-cnt', 2, 1);
    };
    PostsComponent = __decorate([
        core_1.Component({
            selector: 'posts-component',
            templateUrl: 'app/posts/posts.component.html',
            providers: [posts_service_1.PostsService],
            directives: [wait_component_1.WaitComponent]
        }), 
        __metadata('design:paramtypes', [posts_service_1.PostsService])
    ], PostsComponent);
    return PostsComponent;
}());
exports.PostsComponent = PostsComponent;
//# sourceMappingURL=posts.component.js.map