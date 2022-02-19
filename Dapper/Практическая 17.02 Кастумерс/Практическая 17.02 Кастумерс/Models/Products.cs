using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_17._02_Кастумерс
{
    internal class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public Category CategoryId { get; set; }
        public int CategoryId { get; set; }
        //public Countries CountryId { get; set; }
        public int CountryId { get; set; }
    }
}
