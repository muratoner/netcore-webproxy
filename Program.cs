﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace NetCoreHttpClientProxy
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ProxyUrl = "http://localhost:8888";
            const string ProxyUsername = "";
            const string ProxyPassword = "";
            const string RequestUrl = "https://enfetib4klozkbb.m.pipedream.net";
            var proxy = new WebProxy
            {
                Address = new(ProxyUrl),
                Credentials = new NetworkCredential(ProxyUsername, ProxyPassword)
            };
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            };
            using var client = new HttpClient(httpClientHandler);
            var response = await client.GetAsync(RequestUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync(); 
                Console.WriteLine(responseString);
            }
        }
    }
}