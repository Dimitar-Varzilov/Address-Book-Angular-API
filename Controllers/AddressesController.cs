using AddressBookAPI.Services.AddressService;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly IAddressService _addressService;

		public AddressesController(IAddressService addressService)
		{
			_addressService = addressService;
		}

		// GET: api/Addresses
		[HttpGet]
		public async Task<ActionResult<List<Address>>> GetAddressesAsync()
		{
			return await _addressService.GetAddressesAsync();
		}

		// GET: api/Addresses/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Address>> GetAddressAsync(int id)
		{
			return await _addressService.GetAddressAsync(id);
		}

		// PUT: api/Addresses/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<ActionResult<List<Address>>> PutAddress(int id, Address address)
		{

			return await _addressService.PutAddress(id, address);
		}

		// POST: api/Addresses
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<List<Address>>> PostAddress(Address address)
		{
			return await _addressService.PostAddressAsync(address);
		}

		// DELETE: api/Addresses/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Address>>> DeleteAddress(int id)
		{
			return await _addressService.DeleteAddressAsync(id);
		}
	}
}
