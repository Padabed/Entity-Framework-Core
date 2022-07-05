using System;
using DatabaseFirst.DTO;

namespace DatabaseFirst.DTO
{
    public class CarDTO
    {
        public CarDTO()
        {
        }
        public int ProdYear { get; set; }
        public int NumOfDoors { get; set; }
        public double EngineCapacity { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        public IEnumerable<RentDTO> rents { get; set; }
    }
}

