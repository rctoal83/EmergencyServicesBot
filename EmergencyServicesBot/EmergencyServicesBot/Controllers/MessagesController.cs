using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Net.Http;
using System.Diagnostics;
using EmergencyServicesBot.Controllers;
using System;
using System.Net;
using Microsoft.Bot.Builder.FormFlow.Advanced;

namespace EmergencyServicesBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeRoot);

                /*ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;

                // return our reply to the user
                Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                await connector.Conversations.ReplyToActivityAsync(reply);*/
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        internal static IDialog<PoliceEmergencyDetails> MakeRoot()
        {
            return Chain.From(() => FormDialog.FromForm(MessagesController.BuildForm));
        }

        private static IForm<PoliceEmergencyDetails> BuildForm()
        {
            var builder = new FormBuilder<PoliceEmergencyDetails>();

            return builder
                .Message("What kind of incident occurred?")
                .Field(nameof(PoliceEmergencyDetails.IncidentType))
                .Message("Where did the incident happen?")
                .Field(nameof(PoliceEmergencyDetails.IncidentPostCode))
                .Field(nameof(PoliceEmergencyDetails.IncidentHouseNumberOrName))
                .Message("What's your contact details?")
                .Field(nameof(PoliceEmergencyDetails.ReporteeName))
                .Field(nameof(PoliceEmergencyDetails.ReporteePostCode))
                .Field(nameof(PoliceEmergencyDetails.ReporteeHouseNumberOrName))
                .Field(nameof(PoliceEmergencyDetails.ReporteePhoneNumber))
                .Build();
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}