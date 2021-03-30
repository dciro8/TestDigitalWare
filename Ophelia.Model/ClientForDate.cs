using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Model
{
    public class ClientForDate
    {
        public DateTime invoiceDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int AgeYears { get; set; }
    }
}
