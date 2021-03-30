using Microsoft.AspNetCore.Mvc;
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
    public class NextSaleController : Controller
    {

        private readonly ILogger<NextSaleController> _logger;
        private readonly GetNextSaleBusiness _ruleBusiness;

        public NextSaleController(ILogger<NextSaleController> logger)
        {
            _logger = logger;

            //leer la cadena
            _ruleBusiness = new GetNextSaleBusiness("CADENACONEXION");
        }
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
