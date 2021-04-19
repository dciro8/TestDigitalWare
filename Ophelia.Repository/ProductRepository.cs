
using Dapper;
using Microsoft.Data.SqlClient;
using Ophelia.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ophelia.Repository
{
    // Principio SOLID
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(string _connectionString) : base(_connectionString)
        {

        }
        public async Task<List<ProductDto>> GetAll()
        {
            List<ProductDto> list = null;

            using (IDbConnection dbConnection = this.Connection)
            {
                dbConnection.Open();

                var result = await dbConnection.QueryAsync<ProductDto>("[USP_GetAllProducts]", new { },
                    commandType: CommandType.StoredProcedure);

                list = result.AsList<ProductDto>();
            }

            return list;
        }
        public async Task<List<ClientForDate>> AllClientForDate()
        {
            List<ClientForDate> list = null;

            using (IDbConnection dbConnection = this.Connection)
            {
                dbConnection.Open();

                var result = await dbConnection.QueryAsync<ClientForDate>("[USP_GetUserMinAge]", new { },
                    commandType: CommandType.StoredProcedure);
                list = result.AsList<ClientForDate>();
            }

            return list;
        }


        public async Task<int> UpdateProduct(ProductDto productDto)
        {
            int resultSentence = 0;

            using (IDbConnection dbConnection = this.Connection)
            {
                dbConnection.Open();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@Id", productDto.Id);
                queryParameters.Add("@Code", productDto.Code);
                queryParameters.Add("@Name", productDto.Name);
                queryParameters.Add("@Price", productDto.Price);
                queryParameters.Add("@Quantity", productDto.Quantity);
                queryParameters.Add("@MinimunAlloweb", productDto.MinimunAlloweb);

                var result = await dbConnection.ExecuteAsync("[USP_INSERT_dbo_Product]", queryParameters,
                    commandType: CommandType.StoredProcedure);

                resultSentence = int.Parse(result.ToString());
            }
            return resultSentence;
        }
        public async Task<int> CreateProduct(ProductDto productDto)
        {
            int resultSentence= 0;
            
            using (IDbConnection dbConnection = this.Connection)
            {
                dbConnection.Open();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@Id", productDto.Id);
                queryParameters.Add("@Code", productDto.Code);
                queryParameters.Add("@Name", productDto.Name);
                queryParameters.Add("@Price", productDto.Price);
                queryParameters.Add("@Quantity", productDto.Quantity);
                queryParameters.Add("@MinimunAlloweb", productDto .MinimunAlloweb);
                queryParameters.Add("@IndicateUpdate", 0);
                
                var result = await dbConnection.ExecuteAsync("[USP_INSERT_dbo_Product]", queryParameters,
                    commandType: CommandType.StoredProcedure);

                resultSentence = int.Parse(result.ToString());
            }
            return resultSentence;
        }
    }
}
