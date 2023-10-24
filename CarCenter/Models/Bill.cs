using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarCenter.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [Display(Name = "Número")]
        public int Number { get; set; }
        [Display(Name = "Data Emissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
        public DateTime EmissionDate { get; set; }
        [Display(Name = "Garantia (dias)")]
        public int Warranty { get; set; }
        [Display(Name = "Valor Venda")]
        public float SalePrice { get; set; }
        [Display(Name = "ID Comprador")]
        public int BuyerId { get; set; }
        [Display(Name = "Comprador")]
        public Client Buyer { get; set;}
        [Display(Name = "ID Vendedor")]
        public int SellerId { get; set; }
        [Display(Name = "Vendedor")]
        public Seller Seller { get; set;}
        [Display(Name = "ID Carro")]
        public int CarId { get; set; }
        [Display(Name = "Carro")]
        public Car Car { get; set; }

    }
}
