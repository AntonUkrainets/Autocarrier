using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocarrier.Data
{
    public class Trip
    {
        public long Id { get; set; }
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public long DriverId { get; set; }
        public long CarId { get; set; }
        public int Cargo { get; set; }
        public int DeliveryTime { get; set; }
    }
}