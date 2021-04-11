
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ophelia.Repository
{
    public class BaseRepository
    {
        private readonly string _connectionString;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public BaseRepository(string connection)
        {
            _connectionString = connection;
        }
    }
}
