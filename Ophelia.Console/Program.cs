using Ophelia.Console.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("\nRequest Generic JWT");

            ListaPrestadorDTO departamento = new ListaPrestadorDTO();
            //HttpClientRest client = new HttpClientRest();
            //RequestResult<ListaPrestadorDTO> respuesta = await client.GetAsync<ListaPrestadorDTO>("https://factorydev.digitalwaresaas.com.co:8085/klinicapi/api/Prestador/GetListLender");
            //if (respuesta.IsSuccessful)
            //{
            //    var departamentoDTO = respuesta.Result;
            //}
            //else
            //{
            //    System.Console.WriteLine(respuesta.ErrorMessage);
            //}
            //System.Console.ReadLine();
        }
    }
}
