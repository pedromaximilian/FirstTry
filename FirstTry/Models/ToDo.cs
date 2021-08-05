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
        [DataType(DataType.MultilineText)]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public bool Done { get; set; }
    }
}
