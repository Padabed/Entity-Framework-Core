using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
	public class Client
	{
		public Client()
		{
		}

		[Key]
        public int IdClient { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }

		public virtual ICollection<ClientOrder> ClientOrders { get; set; }
	}
}

