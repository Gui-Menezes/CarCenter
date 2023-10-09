namespace CarCenter.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime EmissionDate { get; set; }
        public int Warranty { get; set; }
        public float SalePrice { get; set; }
        public int BuyerId { get; set; }
        public Client Buyer { get; set;}
        public int SellerId { get; set; }
        public Seller Seller { get; set;}
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
