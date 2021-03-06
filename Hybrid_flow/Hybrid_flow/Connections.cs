﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mime;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml;

//Add the Newtonsoft.json nuget...
using Newtonsoft.Json;

namespace Hybrid_flow
{
    public class Connections
    {

        //Retrieving Token via Authorization code flow
        public string codeTokenH(string code)
        {
            try
            {
                var credentials = Convert.ToBase64String(
                Encoding.ASCII.GetBytes(Constants.ClientID + ":" + Constants.ClientSecret));

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type",  "authorization_code"),      //authorization code is used in this flow aswell
                    new KeyValuePair<string, string>("redirect_uri", Constants.RedirectURI),
                    new KeyValuePair<string, string>("code", code),
                };

                    var content = new FormUrlEncodedContent(body);
                    var response = client.PostAsync(Constants.TokenEndpoint, content).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                        var accessToken = result["access_token"] as string;
                        
                        //the refresh token is not provided in hybrid flow when retrieving token
                        //var refreshToken = result["refresh_token"] as string;

                        var ACCESS_TOKEN = accessToken;
                        //var REFRESH_TOKEN = refreshToken;

                        return ACCESS_TOKEN;
                    }
                    return "not found";
                }
            }

            catch (WebException ex)   // WebEx.
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}