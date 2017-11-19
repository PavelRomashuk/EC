import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'users',
    templateUrl: './users.component.html'
})
export class UsersComponent {
    public users: User[];

    constructor(http: Http) {
        http.get('http://localhost:50642/api/Users').subscribe(result => {
            this.users = result.json() as User[];
        }, error => console.error(error));
    }
}

interface User {
    UserId: number;
    Name: string;
    EMail: string;
    Phone: string;
    UserType: number;
    PWD: string;
}
