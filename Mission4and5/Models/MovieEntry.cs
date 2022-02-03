using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4and5.Models
{
    public class MovieEntry
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public short Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }

        // Build Foreign Key
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        
        
        // category title year (short) director rating edited(y/n) lent-to notes
    }
}
