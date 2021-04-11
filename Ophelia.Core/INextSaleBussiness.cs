using Ophelia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Core
{
    public    interface INextSaleBussiness
    {
        Task<List<SalesForYear>> GetSalesForYear(string year);


    }
}
