/**
 * Generated by orval v6.27.1 🍺
 * Do not edit manually.
 * DRR API
 * OpenAPI spec version: 1.0.0
 */
import type { ApplicantType } from './applicantType';
import type { LocationInformation } from './locationInformation';
import type { FundingInformation } from './fundingInformation';
import type { ContactDetails } from './contactDetails';
import type { ProjectType } from './projectType';
import type { Hazards } from './hazards';

export interface EOIApplication {
  applicantName?: string;
  applicantType?: ApplicantType;
  backgroundDescription?: string;
  climateAdaptation?: string;
  endDate?: string;
  engagementProposal?: string;
  fundingRequest?: number;
  locationInformation?: LocationInformation;
  otherFunding?: FundingInformation[];
  /** @nullable */
  otherHazardsDescription?: string;
  otherInformation?: string;
  ownershipDeclaration?: boolean;
  projectContacts?: ContactDetails[];
  projectTitle?: string;
  projectType?: ProjectType;
  proposedSolution?: string;
  rationaleForFunding?: string;
  rationaleForSolution?: string;
  /** @nullable */
  reasonsToSecureFunding?: string;
  relatedHazards?: Hazards[];
  startDate?: string;
  submitter?: ContactDetails;
  totalFunding?: number;
  unfundedAmount?: number;
}
