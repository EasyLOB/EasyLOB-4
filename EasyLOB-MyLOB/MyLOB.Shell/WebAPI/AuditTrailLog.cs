using EasyLOB.AuditTrail.Data;
using EasyLOB.Library;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        private static void WebAPIAuditTrailLogPOST()
        {
            AuditTrailLogDTO dto = new AuditTrailLogDTO
            {
                LogDate = DateTime.Today,
                LogTime = DateTime.Now,
                LogUserName = "administrator",
                LogEntity = "AuditTrailLog",
                LogOperation = "C",
                LogId = "1"
            };

            var client = new RestClient(WebAPIUrl);

            var request = new RestRequest("api/AuditTrailLog", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.Timeout = WebAPITimeout;
            request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            // Local Time -> UTC Time
            //request.AddJsonBody(dto);
            // Local Time
            request.AddParameter("application/json", JsonConvert.SerializeObject(dto), ParameterType.RequestBody);

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

        private static void WebAPIAuditTrailLogPUT()
        {
            Console.Write("GET Id ? ");
            string idString = Console.ReadLine();
            int id = idString.ToInt32();

            AuditTrailLogDTO dto = new AuditTrailLogDTO
            {
                Id = id,
                LogDate = DateTime.Today,
                LogTime = DateTime.Now,
                LogUserName = "administrator",
                LogEntity = "AuditTrailLog",
                LogOperation = "C",
                LogId = id.ToString()
            };

            var client = new RestClient(WebAPIUrl);
            var request = new RestRequest("api/AuditTrailLog", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            request.Timeout = WebAPITimeout;
            request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            // Local Time -> UTC Time
            //request.AddJsonBody(dto);
            // Local Time
            request.AddParameter("application/json", JsonConvert.SerializeObject(dto), ParameterType.RequestBody);

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

        private static void WebAPIAuditTrailLogGET1()
        {
            Console.Write("GET Id ? ");
            string idString = Console.ReadLine();
            int id = idString.ToInt32();

            var client = new RestClient(WebAPIUrl);
            var request = new RestRequest("api/AuditTrailLog/{id}", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            request.Timeout = WebAPITimeout;
            request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            request.AddUrlSegment("id", id);

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("\nRESPONSE");
                if (response.Content.ToLower() == "null")
                {
                    WriteHelper.WriteJSON(response.Content);
                }
                else
                {
                    AuditTrailLogDTO dto = JsonConvert.DeserializeObject<AuditTrailLogDTO>(response.Content);
                    WriteHelper.WriteObject(dto);
                }
            }
            else
            {
                WebAPIError(response);
            }
        }

        private static void WebAPIAuditTrailLogGETN(string where = null, string orderBy = null, int? skip = null, int? take = null)
        {
            var client = new RestClient(WebAPIUrl);
            var request = new RestRequest("api/AuditTrailLog/{where}/{orderBy}/{skip}/{take}", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            request.Timeout = WebAPITimeout;
            request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            request.AddUrlSegment("where", where == null ? "null" : where); // .EncodeToBase64());
            request.AddUrlSegment("orderBy", orderBy == null ? "null" : orderBy); // .EncodeToBase64());
            request.AddUrlSegment("skip", skip ?? 0);
            request.AddUrlSegment("take", take ?? 100);

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("\nRESPONSE");
                List<AuditTrailLogDTO> result = JsonConvert.DeserializeObject<List<AuditTrailLogDTO>>(response.Content);
                foreach (AuditTrailLogDTO dto in result)
                {
                    WriteHelper.WriteObject(dto);
                }
            }
            else
            {
                WebAPIError(response);
            }
        }

        private static void WebAPIAuditTrailLogDELETE()
        {
            Console.Write("DELETE Id ? ");
            string idString = Console.ReadLine();
            int id = idString.ToInt32();

            var client = new RestClient(WebAPIUrl);
            var request = new RestRequest("api/AuditTrailLog/{id}", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };
            request.Timeout = WebAPITimeout;
            request.AddHeader("Authorization", string.Format("Bearer {0}", WebAPIToken.Access_Token));
            request.AddUrlSegment("id", id);

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
    }
}
