import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavMenuComponent } from '../app/nav-menu/nav-menu.component';
import { DepartmentComponent } from '../app/department/department.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { APP_BASE_HREF } from '@angular/common';
import { JwtModule } from '@auth0/angular-jwt';
import { ACCESS_TOKEN_KEY } from './service/auth.service'
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { ApiHeaderInterceptor } from './service/apiheaderinterceptor';
import { EmployeeComponent } from './employee/employee.component'


export function tokenGetter() {
    return localStorage.getItem(ACCESS_TOKEN_KEY)
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'login', component: LoginComponent },

        ]),
        JwtModule
    ],
    declarations: [AppComponent, NavMenuComponent, DepartmentComponent, HomeComponent, LoginComponent, EmployeeComponent],
    bootstrap: [AppComponent],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
        JwtHelperService,
        { provide: HTTP_INTERCEPTORS, useClass: ApiHeaderInterceptor, multi: true }
    ]
})
export class AppModule { }