using System.Diagnostics.Contracts;

namespace CarCenter.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearFabrication { get; set; }
        public int YearModel { get; set; }
        public int Chassi { get; set; }
        public float Price { get; set;  }

    }
}
