import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Department } from '../entity/department';
import { Employee } from '../entity/employee';


@Component({
    selector: 'department',
    // ��� ����������� ������ ������������� � ����������� ������������ � ����������� � ���� ������ ���������� � ����������� ������ "����������� ���������"
    templateUrl: './department.component.html',
    styleUrls: ['./department.component.css']
})
export class DepartmentComponent  {

    // ������ �������������
    @Input() departments: Department[];

    @Output() empEvent = new EventEmitter<Employee>();
    
    constructor() {
    }

    // �������� ������ � ���������� ��� �������� ���� ������� � ������������ ���������
    showEmployee(employee) {
        this.empEvent.emit(employee);
    }
}