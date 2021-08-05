using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTry.Models
{
    public class ToDo : BaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        public int Description { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        public DateTime Date { get; set; }
        public bool Done { get; set; }
    }
}
