import { Employee } from './employee';

export class Department {
    constructor(
        public id?: number,
        public fullName?: string,
        public shortName?: string,
        public employees?: Employee[]
    ) { }
}