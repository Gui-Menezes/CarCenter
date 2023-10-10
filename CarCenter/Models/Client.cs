using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CarCenter.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Obrigatório"), MaxLength(30), MinLength(2)]

        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Nascimento")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Telefone")]
        public string Phone { get; set; }
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
