﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyBookWebASP.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		[DisplayName("Display Order")]
		[Range(1, 100, ErrorMessage = "Display order must be between 1 and 100")]
		public int DisplayOrder { get; set; }
		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	}
}