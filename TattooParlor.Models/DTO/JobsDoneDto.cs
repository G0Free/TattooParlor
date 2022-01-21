using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models.DTO
{
    public class JobsDoneDto
    {
        public int JobsDoneId { get; set; }
        public int? customerId { get; set; }
        public int? TattooId { get; set; }
        public DateTime jobDate { get; set; }
        public int Cost { get; set; }
        public bool IsDeleted { get; set; }
    }
}
