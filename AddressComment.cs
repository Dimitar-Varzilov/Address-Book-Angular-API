using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI
{
	public class AddressComment
	{
		[Key]
		public int CommentId { get; set; }

		public string Comment { get; set; } = string.Empty;

		public int AddressId { get; set; }
		public Address? Address { get; set; }
	}
}
