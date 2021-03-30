
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


            var cs = "Server=DESKTOP-0SP4VFM\\DCIRO;Database=Billing;Trusted_Connection=True;";



            //using (IDbConnection dbConnection = this.Connection)
            using (var dbConnection = new SqlConnection(cs))
            {
                dbConnection.Open();

                // DynamicParameters

                var result = await dbConnection.QueryAsync<ProductDto>("[USP_GetAllProducts]", new { },
                    commandType: CommandType.StoredProcedure);

                list = result.AsList<ProductDto>();
            }

            return list;
        }
        public async Task<List<ClientForDate>> AllClientForDate()
        {
            List<ClientForDate> list = null;


            var cs = "Server=DESKTOP-0SP4VFM\\DCIRO;Database=Billing;Trusted_Connection=True;";



            //using (IDbConnection dbConnection = this.Connection)
            using (var dbConnection = new SqlConnection(cs))
            {
                dbConnection.Open();

                // DynamicParameters

                var result = await dbConnection.QueryAsync<ClientForDate>("[USP_GetUserMinAge]", new { },
                    commandType: CommandType.StoredProcedure);

                list = result.AsList<ClientForDate>();
            }

            return list;
        }
    }
}
