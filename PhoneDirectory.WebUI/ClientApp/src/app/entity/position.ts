import { Department } from '../entity/department';
import { Employee } from '../entity/employee';

export class Position {
    public id?: number
    public name?: string
    public department?: Department
    public departmentId?: number
    public employees?: Employee[]
}