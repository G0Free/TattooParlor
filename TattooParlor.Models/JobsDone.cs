using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models
{
    public class JobsDone
    {
        public Customer customer { get; set; }
        public Tattoo  tattoo{ get; set; }

        public DateTime jobDate { get; set; }
        public int Cost { get; set; }
    }
}
