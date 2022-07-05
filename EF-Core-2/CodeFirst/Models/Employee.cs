using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
	public class Employee
	{
		public Employee()
		{
		}

		[Key]
		public int IdEmployee { get; set; }
		public string EmpFirstName { get; set; }
		public string EmpLastName { get; set; }

		public virtual ICollection<ClientOrder> ClientOrders { get; set; }
	}
}

