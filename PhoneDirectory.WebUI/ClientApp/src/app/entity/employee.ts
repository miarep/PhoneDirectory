import { Position } from '../entity/position';

export class Employee {
    public id?: number;
    public fio?: string;
    public tabelNumber?: string;
    public birthDate?: string;
    public email?: string;
    public phone?: string;
    public mobilePhone?: string;
    public photoPath?: string;
    public position?: Position;
    public positionId?: number;
}