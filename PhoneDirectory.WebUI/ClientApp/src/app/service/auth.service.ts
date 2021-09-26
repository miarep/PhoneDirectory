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

    // Адрес контроллера аутентификации
    url = '/api/auth/login';

    // Функция логина
    public login(email: string, password: string) {
        
        return this.http.post<Token>(this.url, { email, password })
            .pipe(tap(token => {
                localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token)
            })
        )        
    }

    // Проверка аутентификации
    isAuthenticated(): boolean {
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token && !this.jwtHelper.isTokenExpired(token);
    }

    // Логаут
    logout(): void {
        localStorage.removeItem(ACCESS_TOKEN_KEY);        
    }

    // Получение токена. Используется в перехватчике http запросов для установки заголовка аутентификации
    getToken() {
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token;
    }
}
