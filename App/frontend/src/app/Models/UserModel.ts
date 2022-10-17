import { BaseModel } from "./BaseModel";
import { RoleModel } from "./RoleModel";
import { TestModel } from "./TestModel";

export class UserModel extends BaseModel {
  email: string;
  roles: Array<RoleModel>;
  tests: Array<TestModel>;

  constructor(id: string, email: string, roles: Array<RoleModel>, tests: Array<TestModel>) {
    super();
      this.id = id;
      this.email = email;
      this.roles = roles ? roles : new Array<RoleModel>();
      this.tests = tests ? tests : new Array<TestModel>();
  }
}