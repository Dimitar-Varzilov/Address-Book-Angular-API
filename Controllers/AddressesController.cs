using AddressBookAPI.Dtos;
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
		public Task<ActionResult<List<Address>>> GetAddressesAsync(int resultsToShow = 100)
		{
			//return _addressService.GetTrimmedAddressesAsync(10);
			return _addressService.GetTrimmedAddressesAsync(resultsToShow);

		}

		// GET: api/Addresses/5
		[HttpGet("{id}")]
		public Task<ActionResult<AddressDto>> GetAddressAsync(int id)
		{
			return _addressService.GetOneAddressAsync(id);
		}

		// POST: api/Addresses
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<List<Address>>> AddAddress(AddressDto newAddress)
		{
			return await _addressService.AddAddressAsync(newAddress);
		}

		// PUT: api/Addresses/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<ActionResult<List<Address>>> UpdateAddress(int id, AddressDto updatedAddress)
		{
			return await _addressService.UpdateAddressAsync(id, updatedAddress);
		}

		// DELETE: api/Addresses/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Address>>> DeleteAddress(int id)
		{
			return await _addressService.DeleteAddressAsync(id);
		}
	}
}
