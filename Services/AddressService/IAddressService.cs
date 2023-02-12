using AddressBookAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Services.AddressService
{
	public interface IAddressService
	{
		Task<ActionResult<List<Address>>> GetAddressesAsync();
		Task<ActionResult<List<Address>>> GetTrimmedAddressesAsync(int count);
		Task<ActionResult<AddressDto>> GetOneAddressAsync(int id);
		Task<ActionResult<List<Address>>> AddAddressAsync(AddressDto address);
		Task<ActionResult<List<Address>>> UpdateAddressAsync(int id, AddressDto address);
		Task<ActionResult<List<Address>>> DeleteAddressAsync(int id);
	}
}
