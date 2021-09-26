import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/internal/operators/map';
import { Employee } from '../entity/employee';

@Injectable()
export class DataService {

    // Адрес контроллера подразделений
    private departmentsUrl = "/api/departments";
    // Адрес контроллера сотрудников
    private employeeUrl = "/api/employee";

    constructor(private http: HttpClient) {
    }

    // Функция получения корневого подразделения
    getRootDepartments() {
        return this.http.get(this.departmentsUrl + '/getrootdepartments');
    }
    // Функция получения сотрудника по идентификатору
    getEmployeeById(id: number) {
        return this.http.get(this.employeeUrl + '/getbyid?id=' + id);
    }
    // Функция получения аутентифицированного сотрудника
    getGetAuthorizeEmployee() {
        return this.http.get(this.employeeUrl + '/getauthorizeemployee');
    }
}