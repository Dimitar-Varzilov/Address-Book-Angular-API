using System.ComponentModel.DataAnnotations;

namespace RestAPIAngular
{
	public class Address
	{
		[Key]
		public int AddressId { get; set; }

		[Required]
		[StringLength(20)]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[StringLength(20)]
		public string LastName { get; set; } = string.Empty;

		[Required]
		public int TelNumber { get; set; }
	}
}
