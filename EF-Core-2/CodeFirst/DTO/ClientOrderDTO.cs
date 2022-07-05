using System;
namespace CodeFirst.DTO
{
	public class ClientOrderDTO
	{
        
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Comments { get; set; }
        public int TotalAmount { get; set; }

        public IEnumerable<ConfectionDTO> Confections { get; set; }

    }
}

