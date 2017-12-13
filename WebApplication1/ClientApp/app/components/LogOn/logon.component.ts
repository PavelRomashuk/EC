import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
//import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'logon',
    templateUrl: './logon.component.html'
})
export class LogonComponent {
    public logon: Logon;

    constructor(private httpClient: Http) {

    }
    ngOnInit() {
        this.logon = new Logon();
    }

    loginUser() {
        var userName = this.logon.Name;
        var userPwd = this.logon.PWD;

        this.httpClient.post('http://localhost:50642/token', { username: userName, password: userPwd }).
            subscribe(
            data => { localStorage.setItem("token", data.text()); });
    }
}

export class Logon {
    Name: string;
    PWD: string;
}