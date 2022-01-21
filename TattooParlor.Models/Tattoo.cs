using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models
{
    [Table("Tattoes")]
    public class Tattoo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TattoId { get; set; }
        public string FantasyName { get; set; }

        [NotMapped]
        public virtual JobsDone jobsDone { get; set; }        
        [ForeignKey(nameof(jobsDone))]
        public int? jobsDoneId { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        [NotMapped]
        public string MainData => $"[{TattoId}] : Fantasyname: {FantasyName}";
    }
}
