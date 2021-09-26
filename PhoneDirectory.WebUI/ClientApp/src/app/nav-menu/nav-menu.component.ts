import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../entity/employee';
import { AuthService } from '../service/auth.service';
import { DataService } from '../service/data.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css'],
    providers: [DataService]
})
export class NavMenuComponent {

    // данные аутентифицированого пользователя
    authorizeEmployee;
        
    @Input('isAuthenticated') isauthenticated: boolean;

    constructor(private router: Router, private auth: AuthService, private data: DataService) {        
    }

    ngOnInit(): void {
        if (this.isauthenticated) {            
            this.authorizeEmployee = this.data.getGetAuthorizeEmployee().subscribe((data: Employee) => this.authorizeEmployee = data);
        }        
    }

    // Пересоздаем компонент в случае изменения 'isauthenticated'
    ngOnChanges() {
        this.ngOnInit();
    }
    
    // Функция логаута. Принудительный редирект на страницу логина
    LogOut() {
        this.auth.logout();
        this.router.navigate(['login']);
    }
}
