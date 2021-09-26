import { Position } from '../entity/position';

export class Department {
    public id?: number
    public fullName?: string
    public shortName?: string
    public positions?: Position[]
    public parent?: Department
    public parentId?: number
    public childrens?: Department[]
}