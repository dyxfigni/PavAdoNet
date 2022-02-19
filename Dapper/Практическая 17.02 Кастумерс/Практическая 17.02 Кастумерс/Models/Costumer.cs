using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_17._02_Кастумерс
{
    internal class Costumer
    {
        public int CostumerId { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public Products ProductId { get; set; }

    }
}
