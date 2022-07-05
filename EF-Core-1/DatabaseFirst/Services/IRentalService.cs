using System;
using System.Collections;
using DatabaseFirst.DTO;

namespace DatabaseFirst.Services
{
	public interface IRentalService
	{
		public Task<CarDTO> GetRentals(int Id);
        
    }
}

