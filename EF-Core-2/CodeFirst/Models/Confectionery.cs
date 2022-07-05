using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
	public class Confectionery
	{
		public Confectionery()
		{
			Confectionery_ClientOrders = new HashSet<Confectionery_ClientOrder>();
		}

		[Key]
		public int IdConfectionery { get; set; }
		public string Name { get; set; }
        public float PricePerOne { get; set; }

        public virtual ICollection<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; }
	}
}

