using AddressBookAPI.Data;
using AddressBookAPI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Services.AddressService
{
	public class AddressService : ControllerBase, IAddressService
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		public AddressService(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ActionResult<List<Address>>> GetAddressesAsync()
		{
			var addresses = await _context.Address.ToListAsync();
			var addressessDto = addresses.Select(address => _mapper.Map<AddressDto>(address));
			return Ok(addressessDto);
		}

		public async Task<ActionResult<List<Address>>> GetTrimmedAddressesAsync(int count)
		{
			
			List<Address> trimmed5addresses = await _context.Address.Take(count).ToListAsync();
			Console.Clear();
			var addressessDto = trimmed5addresses.Select(address => _mapper.Map<AddressDto>(address));
			return Ok(addressessDto);
		}

		public async Task<ActionResult<AddressDto>> GetOneAddressAsync(int id)
		{
			var address = await _context.Address.FindAsync(id);

			if (address == null)
			{
				return NotFound();
			}
			var addressDto = _mapper.Map<AddressDto>(address);
			return addressDto;
		}

		public async Task<ActionResult<List<Address>>> AddAddressAsync(AddressDto newAddress)
		{
			var mappedAddress = _mapper.Map<Address>(newAddress);
			Convert.ToInt32(mappedAddress.PostalCode);
			mappedAddress.LastUpdatedBy = 1;
			_context.Address.Add(mappedAddress);
			await _context.SaveChangesAsync();

			return await GetAddressesAsync();
		}

		public async Task<ActionResult<List<Address>>> UpdateAddressAsync(int id, AddressDto address)
		{
			try
			{
				if (id != address.AddressId)
				{
					return BadRequest();
				}
				else if (!AddressExists(id))
				{
					return NotFound();
				}
				Console.Clear();
				Console.WriteLine(address.PostalCode);
				Convert.ToInt32(address.PostalCode);
				var mappedAddress = _mapper.Map<Address>(address);
				_context.Entry(mappedAddress).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return await GetAddressesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;

			}
		}

		public async Task<ActionResult<List<Address>>> DeleteAddressAsync(int id)
		{
			var address = await _context.Address.FindAsync(id);
			if (address == null)
			{
				return NotFound();
			}

			_context.Address.Remove(address);
			await _context.SaveChangesAsync();

			return await GetAddressesAsync();
		}
		private bool AddressExists(int id)
		{
			return _context.Address.Any(e => e.AddressId == id);
		}
	}
}
