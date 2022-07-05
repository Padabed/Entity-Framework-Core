using System;
using System.Data.SqlClient;
using DatabaseFirst.DTO;

namespace DatabaseFirst.Services
{
	public class RentalService : IRentalService
	{
		public IConfiguration _configuration;
		public RentalService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<CarDTO> GetRentals(int Id)
        {
			using var con = new SqlConnection(_configuration.GetConnectionString("ProductionDB"));
			using var com = new SqlCommand();
			com.Connection = con;

			var rentals = new HashSet<CarDTO>();

			com.CommandText = "Select * FROM rent.Car WHERE IdCar = @id";

			com.Parameters.AddWithValue("id", Id);

			await con.OpenAsync();

			var dr = await com.ExecuteReaderAsync();

			var _id = await dr.ReadAsync();

			if (!_id)
			{
				throw new Exception("There is no Car with provided id exists");
			}

			await con.CloseAsync();

			com.CommandText =
				"Select C.ProdYear, C.NumOfDoors, C.EngineCapacity, C.Model, M.Manufacturer, R.StartDate, R.EndDate, R.RentalPrice, CL.FirstName " +
				"FROM rent.Car C " +
				"JOIN rent.Manufacturer M ON C.IdManufacturer = M.IdManufacturer " +
				"JOIN rent.Rent R ON R.IdCar = C.IdCar " +
				"JOIN rent.Client CL ON CL.IdClient = R.IdClient " +
                "Where C.IdCar = @id " +
				"ORDER BY R.RentalPrice ASC";

			await con.OpenAsync();
			var list = new HashSet<RentDTO>();
			var car = new CarDTO();
			dr = await com.ExecuteReaderAsync();

			while (await dr.ReadAsync())
            {
				var rent = new RentDTO()
				{
					StartDate = DateTime.Parse(dr["StartDate"].ToString()),
					EndDate = DateTime.Parse(dr["EndDate"].ToString()),
					RentalPrice = double.Parse(dr["RentalPrice"].ToString()),
					FirstName = dr["FirstName"].ToString()
				};
				list.Add(rent);
				car = new CarDTO()
				{
					ProdYear = int.Parse(dr["ProdYear"].ToString()),
					NumOfDoors = int.Parse(dr["NumOfDoors"].ToString()),
					EngineCapacity = double.Parse(dr["EngineCapacity"].ToString()),
					Model = dr["Model"].ToString(),
					Manufacturer = dr["Manufacturer"].ToString(),
					rents = list
				};
            }

			return car;
		}

	}
}


