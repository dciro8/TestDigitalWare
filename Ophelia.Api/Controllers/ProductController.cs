﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Ophelia.Common;
using Ophelia.Core;
using Ophelia.Model;

using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace Ophelia.Api.Controllers
{
    [ApiController]
    [Route("api/v1/product")]

    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductBusiness _ruleBusiness;

        private static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Controlador de manejo de transaccion de producto
        /// </summary>
        /// <param name="logger">Parametro de control de error y seguimiento</param>
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                . AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();
            //leer la cadena
            string ConnectionString = Configuration.GetSection("ConnectionStrings").GetSection("ConnectionString").Value;
            _ruleBusiness = new ProductBusiness(ConnectionString);
        }
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// 
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

             /// <summary>
             /// Obtiene los clientes por unas fechas determinada
             /// </summary>
             /// <returns>Clientes filtrados por las fechas indicadas en el HU</returns>
        [HttpPost]
        [Route("CreteProduct")]
        public async Task<int> CreateProduct(ProductDto productDto)
        {
            int result = 0;

            try
            {
                _logger.LogInformation(Resources.Product_Initial_Messages);

                result = await _ruleBusiness.CreateProduct(productDto);

                _logger.LogInformation(Resources.Product_Finally_Messages);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return result;

        }


        /// <summary>
        /// Obtiene los clientes por unas fechas determinada
        /// </summary>
        /// <returns>Clientes filtrados por las fechas indicadas en el HU</returns>
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



    }
}
