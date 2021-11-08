using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Utils;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;

namespace DemoProject.Tests.TestsAPI
{
    [AllureNUnit]
    [TestFixture]
    [AllureSubSuite("Simple Auth test")]
    public class AuthTest
    {
        public new Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        [Test(Description = "Simple Auth")]
        [AllureTag("TC-5")]
        [AllureOwner("Leonid M")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("API")]
        public void VerifyItems()
        {
            log.Info("Start");
            var client = new RestClient("https://restful-booker.herokuapp.com/auth");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-mock-response-name", "Auth Token Missing");
            var body = @"{""username"" : ""admin"",""password"" : ""password123""}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            log.Info("content: " + response.Content);
            Console.WriteLine(response.Content);
        }
    }
}
