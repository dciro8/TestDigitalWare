using System;

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
