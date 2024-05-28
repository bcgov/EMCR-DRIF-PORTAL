import { CommonModule } from '@angular/common';
import { Component, Input, inject } from '@angular/core';
import {
  FormArray,
  FormControl,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { TranslocoModule } from '@ngneat/transloco';
import {
  IFormGroup,
  RxFormBuilder,
  RxFormControl,
} from '@rxweb/reactive-form-validators';
import { DrrInputComponent } from '../drr-input/drr-input.component';
import { DrrTextareaComponent } from '../drr-textarea/drr-textarea.component';
import {
  ProjectDetailsForm,
  StringItemRequired,
} from '../eoi-application/eoi-application-form';

@Component({
  selector: 'drr-step-5',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    TranslocoModule,
    DrrTextareaComponent,
    DrrInputComponent,
  ],
  templateUrl: './step-5.component.html',
  styleUrl: './step-5.component.scss',
})
export class Step5Component {
  formBuilder = inject(RxFormBuilder);

  @Input()
  projectDetailsForm!: IFormGroup<ProjectDetailsForm>;

  ngOnInit() {
    this.projectDetailsForm
      .get('infrastructureImpacted')
      ?.patchValue(
        this.projectDetailsForm
          .get('infrastructureImpactedArray')
          ?.value.map((infrastructure: any) => infrastructure.value)
      );
    this.projectDetailsForm
      .get('infrastructureImpactedArray')
      ?.valueChanges.subscribe((infrastructures: StringItemRequired[]) => {
        this.projectDetailsForm
          .get('infrastructureImpacted')
          ?.patchValue(
            infrastructures.map((infrastructure) => infrastructure.value)
          );
      });
  }

  getFormArray(formArrayName: string) {
    return this.projectDetailsForm.get(formArrayName) as FormArray;
  }

  getFormControl(name: string): FormControl {
    return this.projectDetailsForm.get(name) as FormControl;
  }

  getArrayFormControl(
    controlName: string,
    arrayName: string,
    index: number
  ): RxFormControl {
    return this.getFormArray(arrayName)?.controls[index]?.get(
      controlName
    ) as RxFormControl;
  }

  addInfrastructure() {
    this.getFormArray('infrastructureImpactedArray').push(
      this.formBuilder.formGroup(StringItemRequired)
    );
  }

  removeInfrastructure(index: number) {
    this.getFormArray('infrastructureImpactedArray').removeAt(index);
  }
}
