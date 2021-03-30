using Ophelia.Model;
using Ophelia.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ophelia.Core
{
  public  class GetNextSale
    {
        private readonly NextSaleRepository _repository;

        public GetNextSale(string _connection)
        {
            _repository = new NextSaleRepository(_connection);
        }
        public async Task<NextSale> GetNextDaySale(int id)
        {
            NextSale NextDaySale;

            NextDaySale = await _repository.GetNextSale(id);

            return NextDaySale;
        }
    }
}
