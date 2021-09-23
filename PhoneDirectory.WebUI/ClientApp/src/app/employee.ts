import { Department } from './department';
import { Position } from './position';

export class Employee {
    constructor(
        public Id?: number,
        public FIO?: string,
        public TabelNumber?: string,
        public BirthDate?: string,
        public Email?: string,
        public Phone?: string,
        public MobilePhone?: string,
        public PhotoPath?: string,
        public Department?: Department,
        public Position?: Position

    ) { }
}