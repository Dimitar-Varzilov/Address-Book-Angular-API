using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI
{
	public class Address
	{
		[Key]
		public int AddressId { get; set; }

		[Required]
		[StringLength(10)]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[StringLength(10)]
		public string LastName { get; set; } = string.Empty;

		[Required]
		public string Telephone { get; set; } = string.Empty;

		[Required]
		[MaxLength(4)]
		[MinLength(4)]
		public int PostalCode { get; set; }

		[Required]
		[StringLength(10)]
		public string City { get; set; } = string.Empty;

		[Required]
		public string Country { get; set; } = string.Empty;

		[Required]
		public string UserAddress { get; set; } = string.Empty;

		public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

		public int LastUpdatedBy { get; set; } = 1;
	}
}
