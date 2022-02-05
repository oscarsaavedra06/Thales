import { Employees } from './../Interfaces/Employees';
import { ApiResponse } from './../Interfaces/ApiResponse';
import { Component,  ViewChild } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {

  displayedColumns: string[] = ['id', 'employee_name', 'employee_salary', 'employee_anual_salary', 'employee_age'];
  public employees: Employees[] = [];
  dataSource: any;
  employeId: string = ""
  @ViewChild(MatPaginator) paginator!: MatPaginator;


  constructor(private http: HttpClient) {

  }
  

  getEmployees() {

    let flter = this.employeId;
    let param = flter == "" ? "" : `/${flter}`
    this.http.get<ApiResponse>(environment.employeesApiUrl + param).subscribe(result => {
      // this.employees = result;
      console.log(this.employees)
      let dataSource :Employees[]=[]
      if (result.data != null) {
        if (result.data.length > 0) {
          dataSource = [...result.data]
        }else{
           dataSource.push(result.data)
        }

        this.employees = dataSource;
        this.dataSource = new MatTableDataSource(dataSource);
        this.dataSource.paginator = this.paginator;
      }
    }, error => console.error(error));

  }

  keyPressIdField(event: any) {
    if (!/[0-9]/.test(event.key)) {
      event.preventDefault();
    }
  }
 

  title = 'ThalesTestAngular';
}
