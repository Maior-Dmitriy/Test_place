import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { OptionModel } from 'src/app/Models/OptionModel';
import { TestModel } from 'src/app/Models/TestModel';

@Component({
  selector: 'app-test-item',
  templateUrl: './test-item.component.html',
  styleUrls: ['./test-item.component.scss']
})
export class TestItemComponent implements OnInit {

  @Input() SelectedItem: TestModel;
  @Output() returnToTests = new EventEmitter<void>();

  public isPrepared: boolean = false;
  public isTestStart: boolean = false;
  public isTestFinished: boolean = false;
  public questionCount: number = 0;

  public selectedOptions: Array<OptionModel> = new Array<OptionModel>();

  constructor() { }

  ngOnInit(): void {
  }

  public onEstimate(): number {
    let result = 0;

    this.selectedOptions.forEach(x => {
      if (x.isRight) {
        result++;
      }
    });

    return result;
  }

  public onProceed(): void {
    if (this.isPrepared) {
      this.isTestStart = true;
    }
    else {
      alert("Please press Agree!!!")
    }
  }

  public onNextQuestion(): void {
    if (this.questionCount < this.SelectedItem.questions.length - 1) {
      if( this.selectedOptions[this.questionCount]) {
        this.questionCount++;
      }
      else {
        alert("Please select letter!!!")
      }
    }
    else {
      this.isTestFinished = true;
    }
  }

  public returnBack(): void {
    this.returnToTests.emit();
  }
}
