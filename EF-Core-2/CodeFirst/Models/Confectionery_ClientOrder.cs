using System;
namespace CodeFirst.Models
{
	public class Confectionery_ClientOrder
	{
		public Confectionery_ClientOrder()
		{
		}

		public int IdClientOrder { get; set; }
		public int IdConfectionery { get; set; }
		public int Amount { get; set; }
		public string Comments { get; set; }


		public virtual Confectionery IdConfectioneryNav { get; set; }
		public virtual ClientOrder IdClientOrderNav { get; set; }
	}
}

