using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        #region Properties

        public static string WebAPIUrl
        {
            get { return ConfigurationHelper.AppSettings<string>("WebAPI.Url"); }
        }

        public static string WebAPIUserName
        {
            get { return ConfigurationHelper.AppSettings<string>("WebAPI.UserName"); }
        }

        public static string WebAPIPassword
        {
            get { return ConfigurationHelper.AppSettings<string>("WebAPI.Password"); }
        }

        public static Token _webAPIToken;

        public static Token WebAPIToken
        {
            get
            {
                if (_webAPIToken == null ||
                    string.IsNullOrEmpty(_webAPIToken.Access_Token) ||
                    _webAPIToken.Expires < DateTime.Now.AddMinutes(1))
                {
                    var client = new RestClient(WebAPIUrl);

                    var request = new RestRequest("token", Method.POST);
                    request.AddParameter("grant_type", "password");
                    request.AddParameter("username", WebAPIUserName);
                    request.AddParameter("password", WebAPIPassword);

                    var response = client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        _webAPIToken = JsonConvert.DeserializeObject<Token>(response.Content);
                    }
                }

                return _webAPIToken;
            }
        }

        public static int WebAPITimeout = 60000;

        #endregion Properties

        #region Methods

        public static void WebAPIDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Persistence Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<A> ANONYMOUS Echo");
                Console.WriteLine("<B> ANONYMOUS Exception");
                Console.WriteLine("<1> Token");
                Console.WriteLine("<2> Echo");
                Console.WriteLine("<3> Exception");
                Console.WriteLine("<4> AuditTrailLog POST ( CREATE )");
                Console.WriteLine("<5> AuditTrailLog PUT ( UPDATE )");
                Console.WriteLine("<6> AuditTrailLog GET 1 ( READ )");
                Console.WriteLine("<7> AuditTrailLog GET N ( READ )");
                Console.WriteLine("<8> AuditTrailLog GET N { WHERE Id > 0 ORDER BY Id DESC } { SKIP 0 TAKE 2 } ( READ )");
                Console.WriteLine("<9> AuditTrailLog DELETE ( DELETE )");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('A'):
                    case ('a'):
                        WebAPIEchoGET(false);
                        break;

                    case ('B'):
                    case ('b'):
                        WebAPIExceptionGET(false);
                        break;

                    case ('1'):
                        WebAPITokenPOST();
                        break;

                    case ('2'):
                        WebAPIEchoGET(true);
                        break;

                    case ('3'):
                        WebAPIExceptionGET(true);
                        break;

                    case ('4'):
                        WebAPIAuditTrailLogPOST();
                        break;

                    case ('5'):
                        WebAPIAuditTrailLogPUT();
                        break;

                    case ('6'):
                        WebAPIAuditTrailLogGET1();
                        break;

                    case ('7'):
                        WebAPIAuditTrailLogGETN();
                        break;

                    case ('8'):
                        WebAPIAuditTrailLogGETN("Id > 0", "Id DESC", 0, 2);
                        break;

                    case ('9'):
                        WebAPIAuditTrailLogDELETE();
                        break;
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }

        private static void WebAPITokenPOST()
        {
            var client = new RestClient(WebAPIUrl);

            var request = new RestRequest("token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", WebAPIUserName);
            request.AddParameter("password", WebAPIPassword);

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _webAPIToken = JsonConvert.DeserializeObject<Token>(response.Content);
                WriteHelper.WriteJSON(_webAPIToken);
            }
            else
            {
                Console.WriteLine("\nERROR");
                WriteHelper.WriteJSON(response);
            }
        }

        private static void WebAPIEchoGET(bool authorize)
        {
            var client = new RestClient(WebAPIUrl);
            RestRequest request;
            if (authorize)
            {
                request = new RestRequest("api/WebAPI/Echo/authorize/{value}", Method.GET)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            }
            else
            {
                request = new RestRequest("api/WebAPI/Echo/anonymous/{value}", Method.GET)
                {
                    RequestFormat = DataFormat.Json
                };
            }
            request.Timeout = WebAPITimeout;
            request.AddParameter("value", "MyLOB", ParameterType.UrlSegment);

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("\nRESPONSE");
                WriteHelper.WriteJSON(response.Content);
            }
            else
            {
                WebAPIError(response);
            }
        }

        private static void WebAPIExceptionGET(bool authorize)
        {
            var client = new RestClient(WebAPIUrl);
            RestRequest request;
            if (authorize)
            {
                request = new RestRequest("api/WebAPI/Exception/authorize", Method.GET)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            }
            else
            {
                request = new RestRequest("api/WebAPI/Exception/anonymous", Method.GET)
                {
                    RequestFormat = DataFormat.Json
                };
            }
            request.Timeout = WebAPITimeout;

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("\nRESPONSE");
                try
                {
                    ZOperationResult operationResult = JsonConvert.DeserializeObject<ZOperationResult>(response.Content);
                    WriteHelper.WriteOperationResult(operationResult);
                }
                catch
                {
                    WriteHelper.WriteObject(response.Content);
                }
            }
            else
            {
                WebAPIError(response);
            }
        }

        private static void WebAPIError(IRestResponse response)
        {
            Console.WriteLine("\nERROR");
            try
            {
                ZOperationResult operationResult = JsonConvert.DeserializeObject<ZOperationResult>(response.Content);
                WriteHelper.WriteJSON(operationResult);
            }
            catch
            {
                Console.Write(response.Content);
            }
        }

        #endregion Methods
    }
}