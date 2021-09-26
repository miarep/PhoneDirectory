import { Injectable } from '@angular/core';

import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse} from '@angular/common/http'
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthService } from '../service/auth.service';


@Injectable()

export class ApiHeaderInterceptor implements HttpInterceptor {

    constructor(private auth: AuthService) { }

    // перехватываем все http запросы для установки токена авторизации
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        let token = this.auth.getToken();
        const bearer = 'Bearer ' + token;

        if (bearer) {
            request = request.clone({
                setHeaders: {
                    'Authorization': bearer,
                }
            });
        }

        return next.handle(request)
            .pipe(
                tap(event => {
                    if (event instanceof HttpResponse) {
                    }
                }, error => {

                })
            );

    };
}