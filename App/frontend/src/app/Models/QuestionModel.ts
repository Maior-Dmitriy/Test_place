import { BaseModel } from "./BaseModel";
import { OptionModel } from "./OptionModel";

export class QuestionModel extends BaseModel {
  title: string;
  testId: string;
  options: Array<OptionModel>;
}