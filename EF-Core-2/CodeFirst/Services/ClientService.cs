using System;
using Microsoft.EntityFrameworkCore;
using CodeFirst.DTO;
using CodeFirst.Models;

namespace CodeFirst.Services
{
	public class ClientService : IClientService
	{
		private readonly s22284Context _context;
		public ClientService(s22284Context context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ClientOrderDTO>> GetAllClientOrdersAsync(int IdClient)
        {
			var _client = await _context.Client.FindAsync(IdClient);
			if (_client == null)
				throw new Exception("There is no such client exists");

			var TotalAmount = await _context
				.Confectionery_ClientOrder
				.Where(x => x.IdClientOrderNav.IdClientNav.IdClient == IdClient)
				.SumAsync(x => x.Amount);

			var ClientOrders = await _context
				.ClientOrder
				.Where(x => x.IdClient == IdClient)
				.Select(x => new ClientOrderDTO
				{
					OrderDate = x.OrderDate,
					CompletionDate = x.CompletionDate,
					Comments = x.Comments,
					TotalAmount = TotalAmount,
					Confections = x.Confectionery_ClientOrders.Select(x => new ConfectionDTO
					{
						Name = x.IdConfectioneryNav.Name,
						PricePerOne = x.IdConfectioneryNav.PricePerOne,
						Amount = x.Amount
					})
				}).ToListAsync();

			return ClientOrders;
        }
	}
}

