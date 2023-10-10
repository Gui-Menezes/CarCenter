using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarCenter.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Nome Completo")]
        public string Name { get; set; }
        [Display(Name = "Data Admissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
        public DateTime AdmissionDate { get; set; }
        [Display(Name = "Matrícula")]
        public string Registration { get; set; }
        [Display(Name = "Salário")]
        public float Salary { get; set; }

        // método calc comissão
    }
}
