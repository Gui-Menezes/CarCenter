using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace CarCenter.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Display(Name = "Marca")]
        public string Brand { get; set; }
        [Display(Name = "Modelo")]
        public string Model { get; set; }
        [Display(Name = "Ano de Fabricação")]
        public int YearFabrication { get; set; }
        [Display(Name = "Ano Modelo")]
        public int YearModel { get; set; }
        public int Chassi { get; set; }
        [Display(Name = "Preço")]
        public float Price { get; set;  }

    }
}
