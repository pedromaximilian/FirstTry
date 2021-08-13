using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTry.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[a-zA-Z]+\s[a-zA-Z]+$", ErrorMessage = "Must include Name and LastName")]
        [MaxLength(50)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Maximum 50 characters")]
        public string FullNane { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Street { get; set; }

        public int Number { get; set; }

    }
}
