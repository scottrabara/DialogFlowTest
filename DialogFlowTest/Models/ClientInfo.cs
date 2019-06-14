using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowTest.Models
{
    public class AppSecrets
    {
        public ClientSecrets Secrets { get; set; }
        public string ProjectId { get; set; }
    }
}
