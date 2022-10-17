import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { Router } from "@angular/router";
import { TestModel } from "../Models/TestModel";
import { environment } from 'src/environments/environment';

@Injectable()
export class TestService {

  constructor(private http: HttpClient, private router: Router) { } 

  public getTestById(id: string) {
    return this.http.get<TestModel>(environment.API_BASE_URL + '/api/test/get?id=' + id);
  }
}