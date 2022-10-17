import { Component, OnInit } from '@angular/core';
import { TestService } from 'src/app/Services/TestService';
import { TestModel } from '../../Models/TestModel';
import { AuthService } from '../../Services/AuthService';

@Component({
  selector: 'app-test-list',
  templateUrl: './test-list.component.html',
  styleUrls: ['./test-list.component.scss']
})
export class TestListComponent implements OnInit {

  public tests: Array<TestModel>
  public selectedTest: TestModel;

  constructor(private authService: AuthService, private testService: TestService) { }

  ngOnInit(): void {
    this.authService.userSub.subscribe(user => {
        this.tests = user.tests;
    })
  }

  public getTestById(id: string): void {
    this.testService.getTestById(id).subscribe(res => {
      this.selectedTest = res;
    }); 
  }

  public onBack(): void {
    this.selectedTest = null;
  }
}
