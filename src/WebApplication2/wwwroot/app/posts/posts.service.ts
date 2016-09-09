import {Injectable, OnInit} from '@angular/core';
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';

//const API_KEY = '6c759d320ea37acf99ec363f678f73c0:14:74192489';
const host = 'http://localhost:5000/';

@Injectable()
export class PostsService {
    constructor(private http: Http) { }

    getPosts(count) {
       let endpoint: string = host + 'api/posts' + (count != '' && count != 0 && count != null ? '/' + count : '');                    
       return this.http.get(endpoint).map(res => res.json());      
    }
}