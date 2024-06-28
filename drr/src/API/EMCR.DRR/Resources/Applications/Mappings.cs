﻿using AutoMapper;
using EMCR.DRR.Managers.Intake;
using Microsoft.Dynamics.CRM;

namespace EMCR.DRR.Resources.Applications
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
#pragma warning disable CS8629 // Nullable value type may be null.
            CreateMap<Application, drr_application>(MemberList.None)
                .ForMember(dest => dest.drr_primaryproponent, opt => opt.MapFrom(src => src.ProponentType.HasValue ? (int?)Enum.Parse<ApplicantTypeOptionSet>(src.ProponentType.Value.ToString()) : null))
                .ForMember(dest => dest.drr_Primary_Proponent_Name, opt => opt.MapFrom(src => new account { name = src.ProponentName, drr_bceidguid = src.BCeIDBusinessId }))
                .ForMember(dest => dest.drr_SubmitterContact, opt => opt.MapFrom(src => src.Submitter))
                .ForMember(dest => dest.drr_PrimaryProjectContact, opt => opt.MapFrom(src => src.ProjectContact))
                .ForMember(dest => dest.drr_AdditionalContact1, opt => opt.MapFrom(src => src.AdditionalContact1))
                .ForMember(dest => dest.drr_AdditionalContact2, opt => opt.MapFrom(src => src.AdditionalContact2))
                //.ForMember(dest => dest.drr_drr_application_account, opt => opt.MapFrom(src => src.PartneringProponents))
                .ForMember(dest => dest.drr_fundingstream, opt => opt.MapFrom(src => src.FundingStream.HasValue ? (int?)Enum.Parse<FundingStreamOptionSet>(src.FundingStream.Value.ToString()) : null))
                .ForMember(dest => dest.drr_projecttitle, opt => opt.MapFrom(src => src.ProjectTitle))
                .ForMember(dest => dest.drr_projecttype, opt => opt.MapFrom(src => src.ProjectType.HasValue ? (int?)Enum.Parse<ProjectTypeOptionSet>(src.ProjectType.Value.ToString()) : null))
                .ForMember(dest => dest.drr_summarizedscopestatement, opt => opt.MapFrom(src => src.ScopeStatement))
                .ForMember(dest => dest.drr_hazards, opt => opt.MapFrom(src => src.RelatedHazards.Count() > 0 ? string.Join(",", src.RelatedHazards.Select(h => (int?)Enum.Parse<HazardsOptionSet>(h.ToString()))) : null))
                .ForMember(dest => dest.drr_reasonswhyotherselectedforhazards, opt => opt.MapFrom(src => src.OtherHazardsDescription))
                .ForMember(dest => dest.drr_anticipatedprojectstartdate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.drr_anticipatedprojectenddate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.drr_estimated_total_project_cost, opt => opt.MapFrom(src => src.EstimatedTotal))
                .ForMember(dest => dest.drr_estimateddriffundingprogramrequest, opt => opt.MapFrom(src => src.FundingRequest))
                .ForMember(dest => dest.drr_application_fundingsource_Application, opt => opt.MapFrom(src => src.OtherFunding))
                .ForMember(dest => dest.drr_remaining_amount, opt => opt.MapFrom(src => src.RemainingAmount))
                .ForMember(dest => dest.drr_reasonstosecurefunding, opt => opt.MapFrom(src => src.IntendToSecureFunding))
                .ForMember(dest => dest.drr_ownershipdeclaration, opt => opt.MapFrom(src => src.OwnershipDeclaration.HasValue ? src.OwnershipDeclaration.Value ? (int?)DRRTwoOptions.Yes : (int?)DRRTwoOptions.No : null))
                .ForMember(dest => dest.drr_ownershipdeclarationcontext, opt => opt.MapFrom(src => src.OwnershipDescription))
                .ForMember(dest => dest.drr_locationdescription, opt => opt.MapFrom(src => src.LocationDescription))
                .ForMember(dest => dest.drr_rationaleforfundingrequest, opt => opt.MapFrom(src => src.RationaleForFunding))
                .ForMember(dest => dest.drr_estimatednumberpeopleimpacted, opt => opt.MapFrom(src => src.EstimatedPeopleImpacted.HasValue ? (int?)Enum.Parse<EstimatedNumberOfPeopleOptionSet>(src.EstimatedPeopleImpacted.Value.ToString()) : null))
                .ForMember(dest => dest.drr_impacttocommunity, opt => opt.MapFrom(src => src.CommunityImpact))
                .ForMember(dest => dest.drr_drr_application_drr_criticalinfrastructureimpacted_Application, opt => opt.MapFrom(src => src.InfrastructureImpacted))
                .ForMember(dest => dest.drr_improveunderstandingriskinvestreduction, opt => opt.MapFrom(src => src.DisasterRiskUnderstanding))
                .ForMember(dest => dest.drr_includedtoaddressidentifiedriskhazards, opt => opt.MapFrom(src => src.AddressRisksAndHazards))
                .ForMember(dest => dest.drr_howdoesprojectalignwithdrifsprogramgoals, opt => opt.MapFrom(src => src.DRIFProgramGoalAlignment))
                .ForMember(dest => dest.drr_additionalrelevantinformation1, opt => opt.MapFrom(src => src.AdditionalBackgroundInformation))
                .ForMember(dest => dest.drr_rationalforproposedsolution, opt => opt.MapFrom(src => src.RationaleForSolution))
                .ForMember(dest => dest.drr_engagementwithfirstnationsorindigenousorg, opt => opt.MapFrom(src => src.FirstNationsEngagement))
                .ForMember(dest => dest.drr_plantoengageotherjurisdictionsandparties, opt => opt.MapFrom(src => src.NeighbourEngagement))
                .ForMember(dest => dest.drr_additionalrelevantinformation2, opt => opt.MapFrom(src => src.AdditionalSolutionInformation))
                .ForMember(dest => dest.drr_additionalrelevantinformation3, opt => opt.MapFrom(src => src.AdditionalEngagementInformation))
                .ForMember(dest => dest.drr_climateadaptation, opt => opt.MapFrom(src => src.ClimateAdaptation))
                .ForMember(dest => dest.drr_otherrelevantinformation, opt => opt.MapFrom(src => src.OtherInformation))
                .ForMember(dest => dest.drr_authorizedrepresentative, opt => opt.MapFrom(src => src.AuthorizedRepresentativeStatement.HasValue && src.AuthorizedRepresentativeStatement.Value ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ForMember(dest => dest.drr_foippaconfirmation, opt => opt.MapFrom(src => src.FOIPPAConfirmation.HasValue && src.FOIPPAConfirmation.Value ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ForMember(dest => dest.drr_accuracyofinformation, opt => opt.MapFrom(src => src.InformationAccuracyStatement.HasValue && src.InformationAccuracyStatement.Value ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ForMember(dest => dest.drr_submitteddate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.statuscode, opt => opt.MapFrom(src => (int?)Enum.Parse<ApplicationStatusOptionSet>(src.Status.ToString())))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
                //These are incomplete - but they've really just been for testing...
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.drr_name))
                .ForMember(dest => dest.ProponentType, opt => opt.MapFrom(src => src.drr_primaryproponent.HasValue ? (int?)Enum.Parse<ProponentType>(((ApplicantTypeOptionSet)src.drr_primaryproponent).ToString()) : null))
                .ForMember(dest => dest.ProponentName, opt => opt.MapFrom(src => src.drr_Primary_Proponent_Name.name))
                .ForMember(dest => dest.BCeIDBusinessId, opt => opt.MapFrom(src => src.drr_Primary_Proponent_Name.drr_bceidguid))
                .ForMember(dest => dest.Submitter, opt => opt.MapFrom(src => src.drr_SubmitterContact))
                .ForMember(dest => dest.ProjectContact, opt => opt.MapFrom(src => src.drr_PrimaryProjectContact))
                .ForMember(dest => dest.AdditionalContact1, opt => opt.MapFrom(src => src.drr_AdditionalContact1))
                .ForMember(dest => dest.AdditionalContact2, opt => opt.MapFrom(src => src.drr_AdditionalContact2))
                .ForMember(dest => dest.PartneringProponents, opt => opt.MapFrom(src => src.drr_application_connections1))
                .ForMember(dest => dest.FundingStream, opt => opt.MapFrom(src => src.drr_fundingstream.HasValue ? (int?)Enum.Parse<FundingStream>(((FundingStreamOptionSet)src.drr_fundingstream).ToString()) : null))
                .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.drr_projecttitle))
                .ForMember(dest => dest.ProjectType, opt => opt.MapFrom(src => src.drr_projecttype.HasValue ? (int?)Enum.Parse<ProjectType>(((ProjectTypeOptionSet)src.drr_projecttype).ToString()) : null))
                .ForMember(dest => dest.ScopeStatement, opt => opt.MapFrom(src => src.drr_summarizedscopestatement))
                .ForMember(dest => dest.RelatedHazards, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.drr_hazards) ? src.drr_hazards.Split(',', StringSplitOptions.None).Select(h => Enum.Parse<Hazards>(((HazardsOptionSet)int.Parse(h)).ToString()).ToString()) : null))
                .ForMember(dest => dest.OtherHazardsDescription, opt => opt.MapFrom(src => src.drr_reasonswhyotherselectedforhazards))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.drr_anticipatedprojectstartdate.HasValue ? src.drr_anticipatedprojectstartdate.Value.UtcDateTime : (DateTime?)null))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.drr_anticipatedprojectenddate.HasValue ? src.drr_anticipatedprojectenddate.Value.UtcDateTime : (DateTime?)null))
                .ForMember(dest => dest.EstimatedTotal, opt => opt.MapFrom(src => src.drr_estimated_total_project_cost))
                .ForMember(dest => dest.FundingRequest, opt => opt.MapFrom(src => src.drr_estimateddriffundingprogramrequest))
                .ForMember(dest => dest.OtherFunding, opt => opt.MapFrom(src => src.drr_application_fundingsource_Application))
                .ForMember(dest => dest.RemainingAmount, opt => opt.MapFrom(src => src.drr_remaining_amount))
                .ForMember(dest => dest.IntendToSecureFunding, opt => opt.MapFrom(src => src.drr_reasonstosecurefunding))
                .ForMember(dest => dest.OwnershipDeclaration, opt => opt.MapFrom(src => src.drr_ownershipdeclaration.HasValue ? src.drr_ownershipdeclaration == (int)DRRTwoOptions.Yes : (bool?)null))
                .ForMember(dest => dest.OwnershipDescription, opt => opt.MapFrom(src => src.drr_ownershipdeclarationcontext))
                .ForMember(dest => dest.LocationDescription, opt => opt.MapFrom(src => src.drr_locationdescription))
                .ForMember(dest => dest.RationaleForFunding, opt => opt.MapFrom(src => src.drr_rationaleforfundingrequest))
                .ForMember(dest => dest.EstimatedPeopleImpacted, opt => opt.MapFrom(src => src.drr_estimatednumberpeopleimpacted.HasValue ? (int?)Enum.Parse<EstimatedNumberOfPeople>(((EstimatedNumberOfPeopleOptionSet)src.drr_estimatednumberpeopleimpacted).ToString()) : null))
                .ForMember(dest => dest.CommunityImpact, opt => opt.MapFrom(src => src.drr_impacttocommunity))
                .ForMember(dest => dest.InfrastructureImpacted, opt => opt.MapFrom(src => src.drr_drr_application_drr_criticalinfrastructureimpacted_Application))
                .ForMember(dest => dest.DisasterRiskUnderstanding, opt => opt.MapFrom(src => src.drr_improveunderstandingriskinvestreduction))
                .ForMember(dest => dest.AddressRisksAndHazards, opt => opt.MapFrom(src => src.drr_includedtoaddressidentifiedriskhazards))
                .ForMember(dest => dest.DRIFProgramGoalAlignment, opt => opt.MapFrom(src => src.drr_howdoesprojectalignwithdrifsprogramgoals))
                .ForMember(dest => dest.AdditionalBackgroundInformation, opt => opt.MapFrom(src => src.drr_additionalrelevantinformation1))
                .ForMember(dest => dest.RationaleForSolution, opt => opt.MapFrom(src => src.drr_rationalforproposedsolution))
                .ForMember(dest => dest.FirstNationsEngagement, opt => opt.MapFrom(src => src.drr_engagementwithfirstnationsorindigenousorg))
                .ForMember(dest => dest.NeighbourEngagement, opt => opt.MapFrom(src => src.drr_plantoengageotherjurisdictionsandparties))
                .ForMember(dest => dest.AdditionalSolutionInformation, opt => opt.MapFrom(src => src.drr_additionalrelevantinformation2))
                .ForMember(dest => dest.AdditionalEngagementInformation, opt => opt.MapFrom(src => src.drr_additionalrelevantinformation3))
                .ForMember(dest => dest.ClimateAdaptation, opt => opt.MapFrom(src => src.drr_climateadaptation))
                .ForMember(dest => dest.OtherInformation, opt => opt.MapFrom(src => src.drr_otherrelevantinformation))
                .ForMember(dest => dest.AuthorizedRepresentativeStatement, opt => opt.MapFrom(src => src.drr_authorizedrepresentative == (int)DRRTwoOptions.Yes))
                .ForMember(dest => dest.FOIPPAConfirmation, opt => opt.MapFrom(src => src.drr_foippaconfirmation == (int)DRRTwoOptions.Yes))
                .ForMember(dest => dest.InformationAccuracyStatement, opt => opt.MapFrom(src => src.drr_accuracyofinformation == (int)DRRTwoOptions.Yes))
                .ForMember(dest => dest.SubmittedDate, opt => opt.MapFrom(src => src.drr_submitteddate.HasValue ? src.drr_submitteddate.Value.UtcDateTime : new DateTime()))
                .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.modifiedon.HasValue ? src.modifiedon.Value.UtcDateTime : new DateTime()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int?)Enum.Parse<ApplicationStatus>(((ApplicationStatusOptionSet)src.statuscode).ToString())))
            ;


            CreateMap<FundingInformation, drr_fundingsource>()
                .ForMember(dest => dest.drr_name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.drr_typeoffunding, opt => opt.MapFrom(src => src.Type.HasValue ? (int?)Enum.Parse<FundingTypeOptionSet>(src.Type.Value.ToString()) : null))
                .ForMember(dest => dest.drr_estimated_amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.drr_describethefundingsource, opt => opt.MapFrom(src => src.OtherDescription))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.drr_name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.drr_typeoffunding.HasValue ? (int?)Enum.Parse<FundingType>(((FundingTypeOptionSet)src.drr_typeoffunding).ToString()) : null))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.drr_estimated_amount))
                .ForMember(dest => dest.OtherDescription, opt => opt.MapFrom(src => src.drr_describethefundingsource))
            ;

            CreateMap<ContactDetails, contact>()
                .ForMember(dest => dest.drr_userid, opt => opt.MapFrom(src => src.BCeId))
                .ForMember(dest => dest.firstname, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.lastname, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.jobtitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.drr_phonenumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.emailaddress1, opt => opt.MapFrom(src => src.Email))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
                .ForMember(dest => dest.BCeId, opt => opt.MapFrom(src => src.drr_userid))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstname))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastname))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.jobtitle))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.department))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.drr_phonenumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.emailaddress1))
            ;

            CreateMap<PartneringProponent, account>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            ;

            CreateMap<connection, PartneringProponent>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            ;

            CreateMap<CriticalInfrastructure, drr_criticalinfrastructureimpacted>()
                .ForMember(dest => dest.drr_name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.drr_name))
                ;

            CreateMap<drr_legaldeclaration, DeclarationInfo>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<DeclarationTypeOptionSet>(((DeclarationTypeOptionSet)src.drr_declarationtype).ToString())))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.drr_declarationtext));
        }
    }
}
#pragma warning restore CS8629 // Nullable value type may be null.
