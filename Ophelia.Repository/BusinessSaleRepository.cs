
using Dapper;
using Microsoft.Data.SqlClient;
using Ophelia.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace Ophelia.Repository
{
    public class BusinessSaleRepository : BaseRepository
    {
        public BusinessSaleRepository(string _connectionString) : base(_connectionString)
        {

        }
        public async Task<List<SalesForYear>> SalesForYear(string year)
        {
            List<SalesForYear> nextSale = null;

            using (IDbConnection dbConnection = this.Connection)
            {
                dbConnection.Open();

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@parameter", year);

                var result = await dbConnection.QueryAsync<SalesForYear>("[BSP_GetSaleForYear]", queryParameters,
                    commandType: CommandType.StoredProcedure);

                nextSale = result.AsList<SalesForYear>();
            }
            return nextSale;
        }

        public async Task<NextSale> GetNextSale(int id)
        {
            List<NextSale> nextSale = null;
           
            using (IDbConnection dbConnection = this.Connection)
            {
                dbConnection.Open();

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@parameter ", id);

                var result = await dbConnection.QueryAsync<NextSale>("[USP_GetNextSale]", queryParameters,
                    commandType: CommandType.StoredProcedure);

                nextSale = result.AsList<NextSale>();
            }
            if (nextSale.Count > 0)
                return nextSale[0];
            else
                return new NextSale();
        }


    }
}
