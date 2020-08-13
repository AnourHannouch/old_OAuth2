using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid_flow
{
    public class Constants
    {
            //Variables
            public static string ClientID;
            public static string ClientSecret;                               
            public static string RedirectURI;           //example:http://localhost:<port>/WebForm_HybridFlow.aspx
            public static string State;
            public static string Nonce;
            public static string Scope;
            public static string Response_Type;         //code+id_token for hybrid flow

            public static string grant_type;

            //Authorization Endpoint
            public static string AuthorizeEndPoint;
            //Token Endpoint
            public static string TokenEndpoint;


        public void fieldVar(string[] _testarray)
        {
            ClientID = _testarray[0];
            ClientSecret = _testarray[1];
            RedirectURI = _testarray[2];
            State = _testarray[3];
            Nonce = _testarray[4];
            Scope = _testarray[5];
            Response_Type = _testarray[6];
            AuthorizeEndPoint = _testarray[7];
            TokenEndpoint = _testarray[8];
        }

    }
}