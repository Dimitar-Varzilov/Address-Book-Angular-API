using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI
{
	public class AddressType
	{
		[Key]
		public int Id { get; set; }

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
