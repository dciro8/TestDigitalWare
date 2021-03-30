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
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductBusiness _ruleBusiness;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;

            //leer la cadena
            _ruleBusiness = new ProductBusiness("CADENACONEXION");
        }

        [HttpGet]
        [Route("All")]
        public async Task<List<ProductDto>> All()
        {
            List<ProductDto> list = null;

            try
            {
                _logger.LogInformation(Resources.Product_Initial_Messages);

                list = await _ruleBusiness.GetAllProducts();

                _logger.LogInformation(Resources.Product_Finally_Messages);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return list;

        }

        [HttpGet]
        [Route("AllClientForDate")]
        public async Task<List<ClientForDate>> AllClientForDate()
        {
            List<ClientForDate> list = null;

            try
            {
                _logger.LogInformation(Resources.Product_Initial_Messages);

                list = await _ruleBusiness.AllClientForDate();

                _logger.LogInformation(Resources.Product_Finally_Messages);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return list;

        }


        [HttpGet]
        [Route("GetNextSale")]
        public async Task<List<ClientForDate>> GetNextSale(int id)
        {
            List<ClientForDate> list = null;

            try
            {
                _logger.LogInformation(Resources.Product_Initial_Messages);

                list = await _ruleBusiness.AllClientForDate();

                _logger.LogInformation(Resources.Product_Finally_Messages);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return list;

        }

    }
}
