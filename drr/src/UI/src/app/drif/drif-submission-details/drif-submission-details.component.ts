import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormArray, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslocoModule } from '@ngneat/transloco';
import {
  IFormGroup,
  RxFormBuilder,
  RxFormGroup,
} from '@rxweb/reactive-form-validators';
import { DrifapplicationService } from '../../../api/drifapplication/drifapplication.service';
import {
  EOIApplicationForm,
  FundingInformationItemForm,
  StringItem,
} from '../eoi-application/eoi-application-form';
import { SummaryComponent } from '../summary/summary.component';

@Component({
  selector: 'drif-submission-details',
  standalone: true,
  imports: [
    CommonModule,
    SummaryComponent,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    TranslocoModule,
  ],
  providers: [RxFormBuilder],
  templateUrl: './drif-submission-details.component.html',
  styleUrl: './drif-submission-details.component.scss',
})
export class DrifSubmissionDetailsComponent {
  applicationService = inject(DrifapplicationService);
  route = inject(ActivatedRoute);
  router = inject(Router);
  formBuilder = inject(RxFormBuilder);

  id!: string;
  eoiApplicationForm = this.formBuilder.formGroup(
    EOIApplicationForm
  ) as IFormGroup<EOIApplicationForm>;

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.id = id;

    this.applicationService.dRIFApplicationGet(id).subscribe((application) => {
      // transform application into step forms
      // TODO: refactor this
      const eoiApplicationForm: EOIApplicationForm = {
        proponentInformation: {
          proponentType: application.proponentType,
          additionalContacts: application.additionalContacts,
          partneringProponents: application.partneringProponents,
          submitter: application.submitter,
          projectContact: application.projectContact,
        },
        projectInformation: {
          projectType: application.projectType,
          projectTitle: application.projectTitle,
          scopeStatement: application.scopeStatement,
          fundingStream: application.fundingStream,
          relatedHazards: application.relatedHazards,
          otherHazardsDescription: application.otherHazardsDescription,
          startDate: application.startDate,
          endDate: application.endDate,
        },
        fundingInformation: {
          fundingRequest: application.fundingRequest,
          remainingAmount: application.remainingAmount,
          intendToSecureFunding: application.intendToSecureFunding,
          estimatedTotal: application.estimatedTotal,
        },
        locationInformation: {
          ownershipDeclaration: application.ownershipDeclaration,
          ownershipDescription: application.ownershipDescription,
          locationDescription: application.locationDescription,
        },
        projectDetails: {
          additionalBackgroundInformation:
            application.additionalBackgroundInformation,
          additionalSolutionInformation:
            application.additionalSolutionInformation,
          addressRisksAndHazards: application.addressRisksAndHazards,
          disasterRiskUnderstanding: application.disasterRiskUnderstanding,
          drifProgramGoalAlignment: application.drifProgramGoalAlignment,
          estimatedPeopleImpacted: application.estimatedPeopleImpacted,
          communityImpact: application.communityImpact,
          infrastructureImpacted: application.infrastructureImpacted,
          rationaleForFunding: application.rationaleForFunding,
          rationaleForSolution: application.rationaleForSolution,
        },
        engagementPlan: {
          additionalEngagementInformation:
            application.additionalEngagementInformation,
          firstNationsEngagement: application.firstNationsEngagement,
          neighbourEngagement: application.neighbourEngagement,
        },
        otherSupportingInformation: {
          climateAdaptation: application.climateAdaptation,
          otherInformation: application.otherInformation,
        },
      };

      this.eoiApplicationForm.patchValue(eoiApplicationForm, {
        emitEvent: false,
      });

      const partneringProponentsArray = this.getFormGroup(
        'proponentInformation'
      ).get('partneringProponentsArray') as FormArray;
      partneringProponentsArray.clear();
      application.partneringProponents?.forEach((proponent) => {
        partneringProponentsArray?.push(
          this.formBuilder.formGroup(new StringItem({ value: proponent }))
        );
      });

      const fundingInformationItemFormArray = this.getFormGroup(
        'fundingInformation'
      ).get('otherFunding') as FormArray;
      fundingInformationItemFormArray.clear();
      application.otherFunding?.forEach((funding) => {
        fundingInformationItemFormArray?.push(
          this.formBuilder.formGroup(new FundingInformationItemForm(funding))
        );
      });

      const infrastructureImpactedArray = this.getFormGroup(
        'projectDetails'
      ).get('infrastructureImpactedArray') as FormArray;
      infrastructureImpactedArray.clear();
      application.infrastructureImpacted?.forEach((infrastructure) => {
        infrastructureImpactedArray?.push(
          this.formBuilder.formGroup(new StringItem({ value: infrastructure }))
        );
      });
    });
  }

  getFormGroup(groupName: string) {
    return this.eoiApplicationForm?.get(groupName) as RxFormGroup;
  }

  goBack() {
    this.router.navigate(['/dashboard']);
  }
}
