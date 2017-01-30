using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyServicesBot.Controllers
{
    [Serializable]
    public class PoliceEmergencyDetails
    {
        public PoliceIncidentType IncidentType;

        // Incident Address
        [Prompt("Enter the post code")]
        public string IncidentPostCode;
        [Prompt("Enter the house number")]
        public string IncidentHouseNumberOrName;

        // Reportee Contact details
        [Prompt("Enter your name")]
        public string ReporteeName;
        [Prompt("Enter your post code")]
        public string ReporteePostCode;
        [Prompt("Enter your house number")]
        public string ReporteeHouseNumberOrName;
        [Prompt("Enter your phone number")]
        public string ReporteePhoneNumber;
    }

    [Serializable]
    public class Contactdetails
    {
        [Prompt("Enter your name")]
        public string Name;
        [Prompt("Enter your address")]
        public Address Address;
        [Prompt("Enter your phone number")]
        public int PhoneNumber;
    }

    [Serializable]
    public class Address
    {
        [Prompt("Enter the post code")]
        public string PostCode;
        [Prompt("Enter house number")]
        public string HouseNumberOrName;
    }

    public enum PoliceIncidentType
    {
        [Terms(new string[] { "minor assault" })]
        MinorAssault,
        [Terms(new string[] { "serious assault" })]
        SeriousAssault,
        [Terms(new string[] { "sexual assault" })]
        SexualAssault,
        [Terms(new string[] { "murder", "killing" })]
        Murder,
        [Terms(new string[] { "vandalism" })]
        Vandalism,
        [Terms(new string[] { "anti-social behaviour", "anti social behaviour" })]
        AntiSocialBehaviour,
        [Terms(new string[] { "theft" })]
        Theft,
        [Terms(new string[] { "break in" })]
        BreakIn
    }
}