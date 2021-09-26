import { Component, OnInit } from '@angular/core';
import { DataService } from '../service/data.service';
import { AuthService } from '../service/auth.service';
import { Department } from '../entity/department';
import { Employee } from '../entity/employee';
import { Router } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    providers: [DataService]
})
export class HomeComponent implements OnInit {

    departments: Department[];

    emp: Employee;

    isAuthenticated: boolean;

    constructor(private dataService: DataService, private authService: AuthService, private route: Router) { }

    ngOnInit() {
        this.isAuthenticated = this.authService.isAuthenticated();
        if (this.isAuthenticated) {
            this.loadDepartments();    // �������� ������ ��� ������ ����������  
        }
        else {
            this.route.navigate(['login']); // �������������� �������� �� �������� ������
        }
    }
    // �������� ������ ����� ������
    loadDepartments() {
        this.dataService.getRootDepartments()
            .subscribe((data: Department[]) => this.departments = data);
    }

    // �������� ������ �� ��������� ���������� ��� �������� �������� ����������
    showEmployee(employee: Employee) {
        this.emp = employee;
    }
}
