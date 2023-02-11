using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI.Dtos
{
	public class AddressDto
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
		public string Telephone { get; set; } = string.Empty;

		[Required]
		[MaxLength(4)]
		[MinLength(4)]
		public string PostalCode { get; set; } = string.Empty;

		[Required]
		[StringLength(10)]
		[MinLength(3)]
		public string City { get; set; } = string.Empty;

		[Required]
		public string Country { get; set; } = string.Empty;

		[Required]
		public string UserAddress { get; set; } = string.Empty;
	}
}
