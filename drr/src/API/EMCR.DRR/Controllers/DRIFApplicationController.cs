﻿using System.ComponentModel;
using System.Net.Mime;
using System.Text.Json.Serialization;
using EMCR.DRR.Managers.Intake;
using Microsoft.AspNetCore.Mvc;

namespace EMCR.DRR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class DRIFApplicationController : ControllerBase
    {
        private readonly ILogger<DRIFApplicationController> logger;
        private readonly IIntakeManager intakeManager;


        public DRIFApplicationController(ILogger<DRIFApplicationController> logger, IIntakeManager intakeManager)
        {
            this.logger = logger;
            this.intakeManager = intakeManager;
        }

        [HttpPost("EOI")]
        public async Task<ActionResult<ApplicationResult>> CreateEOIApplication(DrifEoiApplication application)
        {
            var id = await intakeManager.Handle(new DrifEoiApplicationCommand { application = application });
            return Ok(new ApplicationResult { Id = id });
        }
    }

    public class ApplicationResult
    {
        public required string Id { get; set; }
    }

    public class DrifEoiApplication
    {
        public ApplicantType ApplicantType { get; set; }
        public required string ApplicantName { get; set; }
        public required ContactDetails Submitter { get; set; }
        public required IEnumerable<ContactDetails> ProjectContacts { get; set; }
        public required string ProjectTitle { get; set; }
        public ProjectType ProjectType { get; set; }
        public required IEnumerable<Hazards> RelatedHazards { get; set; }
        public string? OtherHazardsDescription { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required decimal FundingRequest { get; set; }
        public required IEnumerable<FundingInformation> OtherFunding { get; set; }
        public required decimal UnfundedAmount { get; set; }
        public string? ReasonsToSecureFunding { get; set; }
        public required decimal TotalFunding { get; set; }
        public required bool OwnershipDeclaration { get; set; }
        public required LocationInformation LocationInformation { get; set; }
        public required string BackgroundDescription { get; set; }
        public required string RationaleForFunding { get; set; }
        public required string ProposedSolution { get; set; }
        public required string RationaleForSolution { get; set; }
        public required string EngagementProposal { get; set; }
        public required string ClimateAdaptation { get; set; }
        public required string OtherInformation { get; set; }
        public required bool IdentityConfirmation { get; set; }
        public required bool FOIPPAConfirmation { get; set; }
        public required bool CFOConfirmation { get; set; }
    }

    public class FundingInformation
    {
        public required string Name { get; set; }
        public required FundingType Type { get; set; }
        public required decimal Amount { get; set; }

    }

    public class LocationInformation
    {
        public required string Description { get; set; }
        public string? Area { get; set; }
        public string? Ownership { get; set; }
    }

    public class ContactDetails
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Title { get; set; }
        public required string Department { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicantType
    {
        [Description("First Nation")]
        FirstNation,

        [Description("Local Government")]
        LocalGovernment,

        [Description("Regional District")]
        RegionalDistrict
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProjectType
    {
        [Description("New Project")]
        New,

        [Description("New Phase of Existing Project")]
        Existing
    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FundingType
    {
        [Description("Fed")]
        Fed,

        [Description("Fed/prov")]
        FedProv,

        [Description("Prov")]
        Prov,

        [Description("Self Funding")]
        SelfFunding,

        [Description("Other Grants")]
        Other,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Hazards
    {
        [Description("Drought and water scarcity")]
        Drought,

        [Description("Erosion")]
        Erosion,

        [Description("Extreme Temperature")]
        ExtremeTemperature,

        [Description("Flood")]
        Flood,

        [Description("Geohazards (e.g., avalanche, landslide)")]
        Geohazards,

        [Description("Sea Level Rise")]
        SeaLevelRise,

        [Description("Seismic")]
        Seismic,

        [Description("Storm")]
        Storm,

        [Description("Tsunami")]
        Tsunami,

        [Description("Other")]
        Other,
    }
}