﻿using NetDist.Jobs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NetDist.Client.WebApi
{
    public class WebApiClient : ClientBase
    {
        private readonly WebApiClientSettings _settings;

        public WebApiClient()
        {
            _settings = new WebApiClientSettings();
        }

        private static void DummyFunctionToMakeSureReferencesGetCopiedProperly()
        {
            System.Net.Http.Formatting.MediaTypeFormatter.GetDefaultValueForType(typeof(object));
        }

        public override Job GetJob()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_settings.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                var response = client.GetAsync(String.Concat("api/client/getjob", "/", ClientInfo.Id)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var job = JsonConvert.DeserializeObject<Job>(content);
                    return job;
                }
            }
            return null;
        }

        public override void SendResult(JobResult result)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_settings.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                var response = client.PostAsJsonAsync("api/client/result", result).Result;
                if (response.IsSuccessStatusCode)
                {
                }
            }
        }
    }
}
