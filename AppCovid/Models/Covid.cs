using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Models
{
    [Table("Covids")]
    public class Covid
    {
        [Key]
        [Display(Name ="Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Mortes")]
        public int Death { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Recuperados")]
        public int Recovered { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório!")]
        [Display(Name = "Casos confirmados")]
        public int Confirmed { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "País afetado")]
        public int CountryId { get; set; }

        [Display(Name = "País")]
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}
