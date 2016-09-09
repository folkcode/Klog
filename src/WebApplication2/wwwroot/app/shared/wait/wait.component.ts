import { Component } from '@angular/core';

@Component({
    selector: 'wait-component',
    templateUrl: 'app/shared/wait/wait.component.html'
})
export class WaitComponent{
    constructor() {
        console.log('cmp constructor call ->');
    }
}
