using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;
using tecnofit.test.api.ViewModels.Services;

namespace tecnofit.test.api.Views.Services
{
    class RestService : IRestService
    {
        HttpClient client;

        public List<dynamic> Items { get; private set; }

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<dynamic> GetDataAsync(string restRequest, string token)
        {
            await Task.Yield();
            try
            {
                var restClient = new RestClient(Constants.RestUrl);
                var request = new RestRequest(restRequest, Method.GET) {RequestFormat = DataFormat.Json};
                request.AddParameter("Authorization", string.Format("Bearer " + token),ParameterType.HttpHeader);
                request.AddHeader("Content-Type", "application/json");
                var content = restClient.Execute(request);

                if (content.IsSuccessful )
                {
                    return JObject.Parse(content.Content);
                }
                return content.ErrorMessage;
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"		x		ERROR {0}", e.Message);
                return e.Message;
            }
            
        }

        public async Task<dynamic> PostItemAsync(dynamic item, string restRequest, string token )
        {
            await Task.Yield();
            
            try
            {
                var json = JsonConvert.SerializeObject (item);
                var restClient = new RestClient(Constants.RestUrl);
                var request = new RestRequest(restRequest, Method.POST) {RequestFormat = DataFormat.Json};
                
                if (!string.IsNullOrWhiteSpace(token))
                    request.AddParameter("Authorization", string.Format("Bearer " + token),ParameterType.HttpHeader);
                
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

                var content = restClient.Execute(request);
                if (content.IsSuccessful )
                {
                    return JObject.Parse(content.Content);
                }
                return content.ErrorMessage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"		x		ERROR {0}", ex.Message);
                return  ex.Message;
            }
        }
    }
}
