using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWebASP.Models
{
	public class Product
	{
		[Key]
		public int ID { get; set; }
		[Required]
		[DisplayName("Product Name")]
		public string Name { get; set; }
		[DisplayName("Product Description")]
		public string Description { get; set; }
		[DisplayName("Quantity")]
		public double Qty { get; set; }
	}
}
