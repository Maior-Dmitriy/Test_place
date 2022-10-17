import { BaseModel } from "./BaseModel";
import { UserModel } from "./UserModel";

export class SignInModel extends BaseModel {
  userId: string;
  accessToken: string;
  expires: Date;
  user: UserModel;
}