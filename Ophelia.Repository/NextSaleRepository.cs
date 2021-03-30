
using Dapper;
using Microsoft.Data.SqlClient;
using Ophelia.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace Ophelia.Repository
{
   public class NextSaleRepository : BaseRepository
    {
        public NextSaleRepository(string _connectionString) : base(_connectionString)
        {

        }
        public async Task<NextSale> GetNextSale(int id)
        {
            NextSale list = null;


            var cs = "Server=DESKTOP-0SP4VFM\\DCIRO;Database=Billing;Trusted_Connection=True;";



            //using (IDbConnection dbConnection = this.Connection)
            using (var dbConnection = new SqlConnection(cs))
            {
                dbConnection.Open();

                // DynamicParameters
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@parameter ", id);

                var result = await dbConnection.QueryAsync<NextSale>("[USP_GetNextSale]", queryParameters,
                    commandType: CommandType.StoredProcedure);

                list = (NextSale)result;
            }

            return list;
        }


    }
}
