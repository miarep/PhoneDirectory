import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { DataService } from '../service/data.service';
import { Employee } from '../entity/employee';

@Component({
    selector: 'employee',
    templateUrl: './employee.component.html',
    styleUrls: ['./employee.component.css']
})

export class EmployeeComponent {

    @Input('emp') e: Employee;

    emp: any;

    constructor(private dataService: DataService) {
        
    }

    ngOnInit(): void {
        if (this.e) {
            this.emp = this.getEmployee(this.e.id);
        }        
    }

    // ����������� ��������� � ������ ��������� 'e' �� ����� �� ����������
    ngOnChanges() {
       this.ngOnInit();
    }

    // ��������� ������ ���������� ����� ������
    getEmployee(id: number) {
        return this.dataService.getEmployeeById(id).subscribe((data: Employee) => this.emp = data);
    }

    // �������������� ���� ���������� � �������
    formateDate(date) {
        let data = new Date(date);        
        return data.toLocaleDateString();
    }
}
