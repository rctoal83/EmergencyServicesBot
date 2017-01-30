using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EmergencyServicesBot.Controllers
{
    [LuisModel("<INSERT LUIS MODEL GUID>", "<INSERT LUIS SUBSCRIPTION GUID>")]
    [Serializable]
    public class ReportPoliceEmergencyDialog : LuisDialog<object>
    {
        private static string BingSearchApiKey = "<INSERT BING SEARCH KEY>";

        /*[LuisIntent("ReportCrime")]
        public async Task ReportCrime(IDialogContext context, LuisResult result)
        {
            string subject = result.Entities[0].Entity;

            //store this subject for the conversation
            context.ConversationData.SetValue<string>("ReportCrime", subject);

            var newsResult = await GetNewsResult(subject);
            if (newsResult != null)
            {
                await context.PostAsync(string.Format("{0} was found in the news", subject));

                foreach (var item in newsResult)
                {
                    string news = string.Format("[{0}]({1})", item.Title, item.Url);
                    await context.PostAsync(news);
                }
            }

            context.Wait(MessageReceived);
        }*/
    }
}