using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Ophelia.Common;
using Ophelia.Core;
using Ophelia.Model;

using System;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ophelia.Api.Controllers
{
    [ApiController]
    [Route("api/v1/NextSale")]
    public class SaleController : Controller
    {

        private readonly ILogger<SaleController> _logger;
        private readonly GetNextSaleBusiness _ruleBusiness;
        private static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Controlador de manejo del negocio de ventas
        /// </summary>
        /// <param name="logger">Parametro de control de error y seguimiento</param>
        public SaleController(ILogger<SaleController> logger)
        {
            _logger = logger;

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
            //leer la cadena
            _ruleBusiness = new GetNextSaleBusiness(Configuration.GetSection("ConnectionStrings").GetSection("ConnectionString").Value);
        }
        /// <summary>
        /// Obtiene las fechas por año
        /// </summary>
        /// <param name="year">Parametro año</param>
        /// <returns>Retorna lista de productos que indican la cantida vendida y el producto</returns>
        [HttpGet]
        [Route("GetSalesForYear")]
        public async Task<List<SalesForYear>> GetSalesForYear(string year)
        {
            List<SalesForYear> nextSale = null;

            try
            {
                _logger.LogInformation(Resources.Product_Initial_Messages);

                nextSale = await _ruleBusiness.GetSalesForYear(year);

                _logger.LogInformation(Resources.Product_Finally_Messages);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return nextSale;

        }
        /// <summary>
        /// Obtiene la fecha de posible venta del producto para el proximo año por cliente
        /// </summary>
        /// <param name="id">Identificacion del cliente</param>
        /// <returns>Fecha de la proxima posible venta del año</returns>
        [HttpGet]
        [Route("GetNextSale")]
        public async Task<NextSale> GetNextSale(int id)
        {
            NextSale nextSale = null;

            try
            {
                _logger.LogInformation(Resources.Product_Initial_Messages);

                nextSale = await _ruleBusiness.GetNextDaySale(id);

                _logger.LogInformation(Resources.Product_Finally_Messages);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return nextSale;
        }
    }
}
