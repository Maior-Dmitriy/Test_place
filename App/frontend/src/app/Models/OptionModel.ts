import { BaseModel } from "./BaseModel";

export class OptionModel extends BaseModel {
  letter: string;
  text: string;
  isRight: boolean;
}