using Ophelia.Model;
using Ophelia.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ophelia.Core
{
  public  class GetNextSaleBusiness
    {
        private readonly BusinessSaleRepository _repository;

        public GetNextSaleBusiness(string _connection)
        {
            _repository = new BusinessSaleRepository(_connection);
        }
        public async Task<NextSale> GetNextDaySale(int id)
        {
            NextSale NextDaySale;

            NextDaySale = await _repository.GetNextSale(id);

            return NextDaySale;
        }
        public async Task<List<SalesForYear>> GetSalesForYear(string year)
        {
            List <SalesForYear> NextDaySale;

            NextDaySale = await _repository.SalesForYear(year);

            return NextDaySale;
        }

        
    }
}
