using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Services.AddressService
{
	public interface IAddressService
	{
		Task<ActionResult<List<Address>>> GetAddressesAsync();

		Task<ActionResult<Address>> GetAddressAsync(int id);

		Task<ActionResult<List<Address>>> PostAddressAsync(Address address);

		Task<ActionResult<List<Address>>> PutAddress(int id, Address address);

		Task<ActionResult<List<Address>>> DeleteAddressAsync(int id);
	}
}
