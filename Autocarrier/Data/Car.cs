using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocarrier.Data
{
    public class Car
    {
        public long Id { get; set; }
        public string Mark { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Price { get; set; }
        public int Tonnage { get; set; }
        public string Number { get; set; }
    }
}