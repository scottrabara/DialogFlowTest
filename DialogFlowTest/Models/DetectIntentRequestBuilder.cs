using DialogFlowTest.Contracts;
using Google.Apis.Dialogflow.v2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowTest.Models
{
    public class DetectIntentRequestBuilder :
        IRequestBuilder<GoogleCloudDialogflowV2DetectIntentRequest>,
        IQueryInputBuilder<GoogleCloudDialogflowV2DetectIntentRequest>,
        ITextInputBuilder<GoogleCloudDialogflowV2DetectIntentRequest>
    {
        private GoogleCloudDialogflowV2DetectIntentRequest request;

        public DetectIntentRequestBuilder()
        {
            request = new GoogleCloudDialogflowV2DetectIntentRequest();
        }

        public static IRequestBuilder<GoogleCloudDialogflowV2DetectIntentRequest> NewRequest => new DetectIntentRequestBuilder();

        public GoogleCloudDialogflowV2DetectIntentRequest Build() => request;

        public IQueryInputBuilder<GoogleCloudDialogflowV2DetectIntentRequest> QueryInput
        {
            get
            {
                request.QueryInput = request.QueryInput ?? new GoogleCloudDialogflowV2QueryInput();
                return this;
            }
        }

        public ITextInputBuilder<GoogleCloudDialogflowV2DetectIntentRequest> TextInput
        {
            get
            {
                request.QueryInput.Text = request.QueryInput?.Text ?? new GoogleCloudDialogflowV2TextInput();
                return this;
            }
        }

        public ITextInputBuilder<GoogleCloudDialogflowV2DetectIntentRequest> WithText(string text)
        {
            request.QueryInput.Text.Text = text;
            return this;
        }

        public ITextInputBuilder<GoogleCloudDialogflowV2DetectIntentRequest> WithLanguageCode(string languageCode)
        {
            request.QueryInput.Text.LanguageCode = languageCode;
            return this;
        }
    }
}
