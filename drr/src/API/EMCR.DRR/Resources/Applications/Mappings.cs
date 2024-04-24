﻿using AutoMapper;
using EMCR.DRR.Managers.Intake;
using Microsoft.Dynamics.CRM;

namespace EMCR.DRR.Resources.Applications
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Application, drr_application>(MemberList.None)
                .ForMember(dest => dest.drr_primaryproponent, opt => opt.MapFrom(src => (int?)Enum.Parse<ApplicantTypeOptionSet>(src.ProponentType.ToString())))
                .ForMember(dest => dest.drr_name, opt => opt.MapFrom(src => src.ProponentName))
                .ForMember(dest => dest.drr_Primary_Proponent_Name, opt => opt.MapFrom(src => new account { name = src.ProponentName }))
                .ForMember(dest => dest.drr_SubmitterContact, opt => opt.MapFrom(src => src.Submitter))
                .ForMember(dest => dest.drr_PrimaryProjectContact, opt => opt.MapFrom(src => src.ProjectContact))
                .ForMember(dest => dest.drr_AdditionalContact1, opt => opt.MapFrom(src => src.AdditionalContact1))
                .ForMember(dest => dest.drr_AdditionalContact2, opt => opt.MapFrom(src => src.AdditionalContact2))
                //.ForMember(dest => dest.drr_drr_application_account, opt => opt.MapFrom(src => src.PartneringProponents))
                .ForMember(dest => dest.drr_fundingstream, opt => opt.MapFrom(src => (int?)Enum.Parse<FundingStreamOptionSet>(src.FundingStream.ToString())))
                .ForMember(dest => dest.drr_projecttitle, opt => opt.MapFrom(src => src.ProjectTitle))
                .ForMember(dest => dest.drr_projecttype, opt => opt.MapFrom(src => (int?)Enum.Parse<ProjectTypeOptionSet>(src.ProjectType.ToString())))
                .ForMember(dest => dest.drr_summarizedscopestatement, opt => opt.MapFrom(src => src.ScopeStatement))
                .ForMember(dest => dest.drr_hazards, opt => opt.MapFrom(src => string.Join(",", src.RelatedHazards.Select(h => (int?)Enum.Parse<HazardsOptionSet>(h.ToString())))))
                .ForMember(dest => dest.drr_reasonswhyotherselectedforhazards, opt => opt.MapFrom(src => src.OtherHazardsDescription))
                .ForMember(dest => dest.drr_anticipatedprojectstartdate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.drr_anticipatedprojectenddate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.drr_estimatedtotalprojectcost, opt => opt.MapFrom(src => src.EstimatedTotal))
                .ForMember(dest => dest.drr_estimateddrifprogramfundingrequest, opt => opt.MapFrom(src => src.FundingRequest))
                .ForMember(dest => dest.drr_application_fundingsource_Application, opt => opt.MapFrom(src => src.OtherFunding))
                .ForMember(dest => dest.drr_remainingamount, opt => opt.MapFrom(src => src.RemainingAmount))
                .ForMember(dest => dest.drr_reasonstosecurefunding, opt => opt.MapFrom(src => src.IntendToSecureFunding))
                .ForMember(dest => dest.drr_ownershipdeclaration, opt => opt.MapFrom(src => src.OwnershipDeclaration ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ForMember(dest => dest.drr_ownershipdeclarationcontext, opt => opt.MapFrom(src => src.OwnershipDescription))
                .ForMember(dest => dest.drr_locationdescription, opt => opt.MapFrom(src => src.LocationDescription))
                .ForMember(dest => dest.drr_rationaleforfundingrequest, opt => opt.MapFrom(src => src.RationaleForFunding))
                .ForMember(dest => dest.drr_estimatednumberofpeopleimpacted, opt => opt.MapFrom(src => src.EstimatedPeopleImpacted))
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
                .ForMember(dest => dest.drr_identityconfirmation, opt => opt.MapFrom(src => src.IdentityConfirmation ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ForMember(dest => dest.drr_foippaconfirmation, opt => opt.MapFrom(src => src.FOIPPAConfirmation ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ForMember(dest => dest.drr_financialawarenessstatement, opt => opt.MapFrom(src => src.FinancialAwarenessConfirmation ? DRRTwoOptions.Yes : DRRTwoOptions.No))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
                //These are incomplete - but they've really just been for testing...
                .ForMember(dest => dest.ProponentName, opt => opt.MapFrom(src => src.drr_name))
                //.ForMember(dest => dest.Submitter, opt => opt.MapFrom(src => src.drr_SubmitterContact))
                //.ForMember(dest => dest.ProjectContact, opt => opt.MapFrom(src => src.drr_application_contact_Application.FirstOrDefault()))
                .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.drr_projecttitle))
                .ForMember(dest => dest.ProjectType, opt => opt.MapFrom(src => src.drr_projecttype))
                //.ForMember(dest => dest.RelatedHazards, opt => opt.MapFrom(src => src.drr_hazards.Split(',', StringSplitOptions.None).Select(h => Enum.Parse<HazardsOptionSet>(h).ToString())))
                .ForMember(dest => dest.OtherHazardsDescription, opt => opt.MapFrom(src => src.drr_reasonswhyotherselectedforhazards))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.drr_anticipatedprojectstartdate.HasValue ? src.drr_anticipatedprojectstartdate.Value.UtcDateTime : new DateTime()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.drr_anticipatedprojectenddate.HasValue ? src.drr_anticipatedprojectenddate.Value.UtcDateTime : new DateTime()))
                .ForMember(dest => dest.FundingRequest, opt => opt.MapFrom(src => src.drr_estimateddrifprogramfundingrequest))
                .ForMember(dest => dest.OtherFunding, opt => opt.MapFrom(src => src.drr_application_fundingsource_Application))
                .ForMember(dest => dest.RemainingAmount, opt => opt.MapFrom(src => src.drr_remainingamount))
                .ForMember(dest => dest.EstimatedTotal, opt => opt.MapFrom(src => src.drr_estimatedtotalprojectcost))
                .ForMember(dest => dest.OwnershipDeclaration, opt => opt.MapFrom(src => src.drr_ownershipdeclaration == (int)DRRTwoOptions.Yes))
                .ForPath(dest => dest.LocationDescription, opt => opt.MapFrom(src => src.drr_locationdescription))
                .ForPath(dest => dest.OwnershipDescription, opt => opt.MapFrom(src => src.drr_ownershipdeclarationcontext))
                .ForMember(dest => dest.EstimatedPeopleImpacted, opt => opt.MapFrom(src => src.drr_estimatednumberofpeopleimpacted))
                .ForMember(dest => dest.RationaleForFunding, opt => opt.MapFrom(src => src.drr_rationaleforfundingrequest))
                .ForMember(dest => dest.AdditionalSolutionInformation, opt => opt.MapFrom(src => src.drr_proposedsolution))
                .ForMember(dest => dest.RationaleForSolution, opt => opt.MapFrom(src => src.drr_rationalforproposedsolution))
                .ForMember(dest => dest.FirstNationsEngagement, opt => opt.MapFrom(src => src.drr_engagementwithfirstnationsorindigenousorg))
                .ForMember(dest => dest.ClimateAdaptation, opt => opt.MapFrom(src => src.drr_climateadaptation))
                .ForMember(dest => dest.OtherInformation, opt => opt.MapFrom(src => src.drr_otherrelevantinformation))
                .ForMember(dest => dest.IdentityConfirmation, opt => opt.MapFrom(src => src.drr_identityconfirmation == (int)DRRTwoOptions.Yes))
                .ForMember(dest => dest.FOIPPAConfirmation, opt => opt.MapFrom(src => src.drr_foippaconfirmation == (int)DRRTwoOptions.Yes))
                .ForMember(dest => dest.FinancialAwarenessConfirmation, opt => opt.MapFrom(src => src.drr_financialawarenessstatement == (int)DRRTwoOptions.Yes))
            ;

            CreateMap<FundingInformation, drr_fundingsource>()
                .ForMember(dest => dest.drr_name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.drr_typeoffunding, opt => opt.MapFrom(src => (int?)Enum.Parse<FundingTypeOptionSet>(src.Type.ToString())))
                .ForMember(dest => dest.drr_estimatedamount, opt => opt.MapFrom(src => src.Amount))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.drr_name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.drr_typeoffunding))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.drr_estimatedamount))
            ;

            CreateMap<ContactDetails, contact>()
                .ForMember(dest => dest.firstname, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.lastname, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.jobtitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.drr_phonenumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.emailaddress1, opt => opt.MapFrom(src => src.Email))
                .ReverseMap()
                .ValidateMemberList(MemberList.Destination)
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

            CreateMap<CriticalInfrastructure, drr_criticalinfrastructureimpacted>()
                .ForMember(dest => dest.drr_name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
