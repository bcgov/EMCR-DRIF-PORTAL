/**
 * Generated by orval v6.27.1 🍺
 * Do not edit manually.
 * DRR API
 * OpenAPI spec version: 1.0.0
 */
import type { ContactDetails } from './contactDetails';
import type { EstimatedNumberOfPeople } from './estimatedNumberOfPeople';
import type { FundingStream } from './fundingStream';
import type { FundingInformation } from './fundingInformation';
import type { ProjectType } from './projectType';
import type { ProponentType } from './proponentType';
import type { Hazards } from './hazards';
import type { ApplicationStatus } from './applicationStatus';

export interface DrifEoiApplication {
  /** @nullable */
  additionalBackgroundInformation?: string;
  additionalContacts?: ContactDetails[];
  /** @nullable */
  additionalEngagementInformation?: string;
  /** @nullable */
  additionalSolutionInformation?: string;
  addressRisksAndHazards?: string;
  authorizedRepresentativeStatement?: boolean;
  climateAdaptation?: string;
  communityImpact?: string;
  disasterRiskUnderstanding?: string;
  drifProgramGoalAlignment?: string;
  endDate?: string;
  estimatedPeopleImpacted?: EstimatedNumberOfPeople;
  /**
   * @minimum 0
   * @maximum 999999999.99
   */
  estimatedTotal?: number;
  firstNationsEngagement?: string;
  /** @nullable */
  foippaConfirmation?: boolean;
  /**
   * @minimum 0
   * @maximum 999999999.99
   */
  fundingRequest?: number;
  fundingStream?: FundingStream;
  informationAccuracyStatement?: boolean;
  infrastructureImpacted?: string[];
  /** @nullable */
  intendToSecureFunding?: string;
  locationDescription?: string;
  neighbourEngagement?: string;
  otherFunding?: FundingInformation[];
  /** @nullable */
  otherHazardsDescription?: string;
  /** @nullable */
  otherInformation?: string;
  ownershipDeclaration?: boolean;
  /** @nullable */
  ownershipDescription?: string;
  partneringProponents?: string[];
  projectContact?: ContactDetails;
  projectTitle?: string;
  projectType?: ProjectType;
  proponentName?: string;
  proponentType?: ProponentType;
  rationaleForFunding?: string;
  rationaleForSolution?: string;
  relatedHazards?: Hazards[];
  remainingAmount?: number;
  scopeStatement?: string;
  startDate?: string;
  status?: ApplicationStatus;
  submitter?: ContactDetails;
}
