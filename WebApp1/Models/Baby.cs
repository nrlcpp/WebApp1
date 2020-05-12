using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Baby
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MaxLength(3)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public float Lenght { get; set; }
        public string Sex { get; set; }
    }
}
