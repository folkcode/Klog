"use strict";
/// <reference path="../animation/main.d.ts" />
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var app_component_1 = require('./app.component');
var posts_service_1 = require('./posts/posts.service');
var http_1 = require('@angular/http');
platform_browser_dynamic_1.bootstrap(app_component_1.AppComponent, [http_1.HTTP_PROVIDERS, posts_service_1.PostsService]);
//# sourceMappingURL=main.js.map