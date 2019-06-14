using DialogFlowTest.Models;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Dialogflow.v2;
using Google.Apis.Dialogflow.v2.Data;
using Google.Apis.Services;

namespace DialogFlowTest
{
    class Program
    {
        static bool Conversing = true;
        static void Main(string[] args)
        {
            Console.WriteLine("== Testing DialogFlow api and service ==");
            Console.WriteLine("== Start speaking below: ==");

            // Authenticate with google OAuth2.0 servers
            UserCredential credential;
            AppSecrets settings;

            // Requires app secrets
            using (var reader = new JsonTextReader(new StreamReader("appSecrets.json")))
            {
                settings = new JsonSerializer().Deserialize<AppSecrets>(reader);
            }

            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                // Client secrets for DialogFlowTest app
                settings.Secrets,
                new[]
                {
                    DialogflowService.ScopeConstants.CloudPlatform,
                    DialogflowService.ScopeConstants.Dialogflow
                },
                "user",
                CancellationToken.None)
                .Result;
            

            if (credential == null) return;

            // Initialize the dialog flow service using credential
            var dialogFlowService = new DialogflowService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DialogFlowTest",

            });

            // Assign HttpClient baseAddress
            dialogFlowService.HttpClient.BaseAddress = new Uri(dialogFlowService.BaseUri);

            // Main conversing loop
            while (Conversing)
            {
                var textInput = Console.ReadLine();

                var request = DetectIntentRequestBuilder
                    .NewRequest
                    .QueryInput.TextInput
                    .WithText(textInput)
                    .WithLanguageCode(LanguageCodeConst.enUS)
                    .Build();

                var response = dialogFlowService.HttpClient.PostAsync($"/v2/projects/{settings.ProjectId}/agent/sessions/123456789:detectIntent",
                    new StringContent(dialogFlowService.Serializer.Serialize(request), Encoding.UTF8, "application/json"))
                    .Result;

                var dialogFlowResponse = dialogFlowService.Serializer.Deserialize<GoogleCloudDialogflowV2DetectIntentResponse>(response.Content.ReadAsStreamAsync().Result);

                Console.WriteLine($"Agent: {dialogFlowResponse?.QueryResult?.FulfillmentText ?? "You did not enter anything"}");

                Conversing = textInput.ToUpper() == "GOODBYE" ? false : true ;
            }
            
            Console.ReadKey();
        }
    }
}
