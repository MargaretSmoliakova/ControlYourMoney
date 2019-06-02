using System;
using System.Net.Http;

namespace ControlYourMoney_Android
{
    public class TestButton
    {
        private static HttpClient client = new HttpClient();

        public static string MakeTestRequest(string mobileInput)
        {
            return Request(mobileInput);
        }

        private static string Request(string mobileInput)
        {
            var testUri = $"http://10.0.2.2:5005/api/incoming?mobileInput={mobileInput}";

            var response = client.GetAsync(testUri).Result;
            var result = String.Empty;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}