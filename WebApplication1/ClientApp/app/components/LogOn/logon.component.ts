import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'logon',
    templateUrl: './logon.component.html'
})
export class UsersComponent {
    public logon: Logon;

    constructor(http: Http) {
        http.get('http://localhost:50642/api/Users').subscribe(result => {
            this.logon = result.json() as Logon;
        }, error => console.error(error));
    }
}

interface Logon {
    Name: string;
    PWD: string;
}