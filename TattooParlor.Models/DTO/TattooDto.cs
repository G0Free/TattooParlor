using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models.DTO
{
    public class TattooDto
    {
        public int TattooId { get; set; }
        public string FantasyName { get; set; }
        public int? jobsDoneId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
