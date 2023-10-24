namespace CarCenter.Models.ViewModels
{
    public class BillFormViewModel
    {
        public Bill Bill { get; set; }
        public List<Client> Clients { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Car> Cars { get; set; }

    }
}
