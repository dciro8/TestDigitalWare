using Newtonsoft.Json;
using Ophelia.Console.Test.Model;
using OpheliaSuiteV2.Core.Klinic.HttpClient.Application.Implementations;
using OpheliaSuiteV2.Core.SSB.Lib.Models;
using RestSharp;
using System.Collections.Generic;

namespace Ophelia.Console.Test
{
    class Program
    {
        public static string urlReq
        {
            get => "https://factorydev.digitalwaresaas.com.co:8085/klinicapi/api/Prestador/GetListLender";
            
        }
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            #region test1
                var clientRestSharp = new RestClient(urlReq);

                clientRestSharp.AddDefaultHeader("Content-type", "application/json");
                clientRestSharp.AddDefaultHeader("Accept", "application/json");
                clientRestSharp.AddDefaultHeader("Cache-Control", "no-cache");

                var request = new RestRequest();
                var timeline = await clientRestSharp.ExecuteAsync<List<ListaPrestadorDTO>>(request);
                var prestadorDTO = 
                JsonConvert.DeserializeObject<RequestResult<List<ListaPrestadorDTO>>>(timeline.Content);
            #endregion

            #region test2
                HttpClientRestAppService client = new HttpClientRestAppService();
                RequestResult<List<object>> respuesta =
                await client.GetAsync<List<object>>(urlReq);

                if (respuesta.IsSuccessful)
                {
                    var GetListLender = respuesta.Result;
                    System.Console.WriteLine(respuesta.Result);
                }
                else
                {
                    System.Console.WriteLine(respuesta.ErrorMessage);
                }

                System.Console.ReadLine();
            #endregion test2
        }
    }
}
