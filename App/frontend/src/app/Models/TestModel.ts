import { BaseModel } from "./BaseModel";
import { QuestionModel } from "./QuestionModel";

export class TestModel extends BaseModel {
  name: string;
  description: string;
  questions: Array<QuestionModel>;
}