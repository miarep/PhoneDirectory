import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Department } from '../entity/department';
import { Employee } from '../entity/employee';


@Component({
    selector: 'department',
    // ƒл€ отображени€ списка подразделений с неизвестной вложенностью и отображени€ в этом списке должностей и сотрудников сделал "рекурсивный компонент"
    templateUrl: './department.component.html',
    styleUrls: ['./department.component.css']
})
export class DepartmentComponent  {

    // ћассив подразделений
    @Input() departments: Department[];

    @Output() empEvent = new EventEmitter<Employee>();
    
    constructor() {
    }

    // ѕередаем данные о сотруднике чью карточку надо открыть в родительский компонент
    showEmployee(employee) {
        this.empEvent.emit(employee);
    }
}