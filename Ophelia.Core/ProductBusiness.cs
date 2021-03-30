using Ophelia.Model;
using Ophelia.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ophelia.Core
{
    public class ProductBusiness
    {
        private readonly ProductRepository _repository;

        public ProductBusiness(string _connection)
        {
            _repository = new ProductRepository(_connection);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            List<ProductDto> list;

            list = await _repository.GetAll();

            return list;
        }

        public async Task<List<ClientForDate>> AllClientForDate()
        {
            List<ClientForDate> list;

            list = await _repository.AllClientForDate();

            return list;
        }

    

    }
}
