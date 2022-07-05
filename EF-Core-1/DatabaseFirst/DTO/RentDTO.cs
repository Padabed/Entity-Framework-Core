using System;
namespace DatabaseFirst.DTO
{
	public class RentDTO
	{
		public RentDTO()
		{
		}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentalPrice { get; set; }
        public string FirstName { get; set; }

    }
}

