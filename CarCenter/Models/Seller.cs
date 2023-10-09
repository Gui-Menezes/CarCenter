namespace CarCenter.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Registration { get; set; }
        public float Salary { get; set; }

        // método calc comissão
    }
}
