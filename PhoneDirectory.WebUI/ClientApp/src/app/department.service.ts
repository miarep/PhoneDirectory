import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Department } from './department';

@Injectable()
export class DepartmentService {

    private url = "/api/departments";

    constructor(private http: HttpClient) {
    }

    get() {
        return this.http.get(this.url);
    }
}