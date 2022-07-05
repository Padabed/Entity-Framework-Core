using System;
using CodeFirst.DTO;

namespace CodeFirst.Services
{
	public interface IClientService
	{
		Task<IEnumerable<ClientOrderDTO>> GetAllClientOrdersAsync(int IdClient);
	}
}

