import { Injectable } from '@angular/core';
import decode from 'jwt-decode';

@Injectable()

export class AuthService {

    public getToken(): string | null {
        return localStorage.getItem('token');
}

    public tokenNotExpired(token: string | null): boolean {
        if (token == null)
            return true;
        else
            return false;
}

    public isAuthenticated(): boolean {
    // get the token
    var token = this.getToken();
    // return a boolean reflecting 
    // whether or not the token is expired
    return this.tokenNotExpired(token);
}
}