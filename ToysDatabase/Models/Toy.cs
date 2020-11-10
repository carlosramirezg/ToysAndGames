using System.ComponentModel.DataAnnotations;

namespace ToysApi.Models
{
	public class Toy
	{
		[Required]
		public int Id { get; set; }
		
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		
		[Required]
		[StringLength(100)]
		public string Description { get; set; }
		
		[Required]
		[Range(0, 100)]
		public int AgeRestriction { get; set; }
		
		[Required]
		[StringLength(100)]
		public string Company { get; set; }
		
		[Required]
		[Range(0, 999.99)]
		public decimal Price { get; set; }
	}
}
