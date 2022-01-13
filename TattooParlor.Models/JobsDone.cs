using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models
{
    [Table("JobsDones")]
    public class JobsDone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int customerId { get; set; }

        [NotMapped]
        public virtual Customer customer { get; set; }


        [ForeignKey(nameof(Tattoo))]
        public int TattooId { get; set; }

        [NotMapped]
        public virtual Tattoo tattoo { get; set; }


        public DateTime jobDate { get; set; }
        public int Cost { get; set; }
        public string MainData => $"[{JobId}] : CustomerId: {customerId} | TattooId: {TattooId} | Date: {jobDate} | Cost: {Cost}";
    }
}
