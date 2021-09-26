import { Component } from '@angular/core';
import { AuthService } from './service/auth.service'

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
    
})
export class AppComponent {

    currentYear: number = new Date().getFullYear();

    isAuthenticated: boolean;

    constructor(private auth: AuthService) {
    }

    onRouterOutletActivate($event) {
        this.isAuthenticated = this.auth.isAuthenticated();
    }
}