import { Component, OnInit } from '@angular/core';
import { DepartmentService } from './department.service';
import { Department } from './department';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DepartmentService]
})
export class AppComponent implements OnInit {

    departments: Department[];                // массив товаров

    constructor(private departmentService: DepartmentService) { }

    ngOnInit() {
        this.loadDepartments();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadDepartments() {
        this.departmentService.get()
            .subscribe((data: Department[]) => this.departments = data);
    }
}