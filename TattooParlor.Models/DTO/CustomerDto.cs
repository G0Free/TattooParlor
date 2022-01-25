using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models.Attributes;

namespace TattooParlor.Models.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailValidator(allowedDomain: "name@test.com", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        public int BirthYear { get; set; }
        public int? JobsDoneId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
