﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BirthYear { get; set; }

        public DateTime CreatedAt { get; set; }
        public  bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        [NotMapped]
        public virtual JobsDone JobsDone { get; set; }
        [ForeignKey(nameof(JobsDone))]
        public int? JobsDoneId { get; set; }

        [NotMapped]
        public string MainData => $"[{CustomerId}] : {FirstName} {LastName} | Email: {Email} | Birthyear: {BirthYear}";


    }
}
