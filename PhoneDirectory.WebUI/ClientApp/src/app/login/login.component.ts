import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { Router } from '@angular/router';

export class Account {
    constructor(public email: string, public password: number) {

    }
}

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit {

    // ������ ��� ����� �������������� �� ���������
    loginForm: any = {
        email: 'ivanov@mail.ru',
        password: '1234',
    }

    constructor(private auth: AuthService, private router: Router) { }

    ngOnInit(): void {
    }

    // ������� ����� � �������. � ������ �������� �������������� ���������� �� ������� ��������
    SignIn() {
        this.auth.login(this.loginForm.email, this.loginForm.password)
            .subscribe(res => {
                this.router.navigate(['']);
            }, error => {
                alert("������ ��������������");
                this.router.navigate(['login']);
            }
        )
    }

}
