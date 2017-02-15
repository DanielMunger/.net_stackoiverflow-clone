using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int Votes { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
