import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { Token } from '../entity/token';
import { tap } from 'rxjs/operators';
import { Department } from '../entity/department';

export const ACCESS_TOKEN_KEY = 'access_token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    constructor(
        private http: HttpClient,
        private jwtHelper: JwtHelperService,
        private router: Router
    ) { }

    // ����� ����������� ��������������
    url = '/api/auth/login';

    // ������� ������
    public login(email: string, password: string) {
        
        return this.http.post<Token>(this.url, { email, password })
            .pipe(tap(token => {
                localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token)
            })
        )        
    }

    // �������� ��������������
    isAuthenticated(): boolean {
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token && !this.jwtHelper.isTokenExpired(token);
    }

    // ������
    logout(): void {
        localStorage.removeItem(ACCESS_TOKEN_KEY);        
    }

    // ��������� ������. ������������ � ������������ http �������� ��� ��������� ��������� ��������������
    getToken() {
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token;
    }
}
