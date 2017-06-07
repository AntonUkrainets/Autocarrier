using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocarrier.Data
{
    public class Driver
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public int Experience { get; set; }
        public int Income { get; set; }
        public string City { get; set; }
        public int TelephoneNumber { get; set; }
    }
}