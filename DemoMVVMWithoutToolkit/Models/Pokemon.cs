using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVVMWithoutToolkit.Models
{

    public class Pokemon
    {
        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(100, ErrorMessage = "{0} mag maximaal {1} karakters bevatten")] 
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(50, ErrorMessage = "{0} mag maximaal {1} karakters bevatten")] public string Type { get; set; } = string.Empty;
    }
}
