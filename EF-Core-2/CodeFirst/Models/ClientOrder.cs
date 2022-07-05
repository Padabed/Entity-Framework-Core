using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
	public class ClientOrder
	{
        public ClientOrder()
        {
            Confectionery_ClientOrders = new HashSet<Confectionery_ClientOrder>();
        }

        [Key]
        public int IdClientOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Comments { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }


        public virtual Client IdClientNav { get; set; }
        public virtual Employee IdEmployeeNav { get; set; }


        public virtual ICollection<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; }
    }
}

