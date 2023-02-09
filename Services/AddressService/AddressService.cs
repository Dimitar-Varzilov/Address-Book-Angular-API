using AddressBookAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Services.AddressService
{
	public class AddressService : ControllerBase, IAddressService
	{
		private readonly DataContext _context;
		public AddressService(DataContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<List<Address>>> GetAddressesAsync()
		{
			return await _context.Address.ToListAsync();
		}

		public async Task<ActionResult<Address>> GetAddressAsync(int id)
		{
			var address = await _context.Address.FindAsync(id);

			if (address == null)
			{
				return NotFound();
			}

			return address;
		}

		public async Task<ActionResult<List<Address>>> PostAddressAsync(Address address)
		{
			_context.Address.Add(address);
			await _context.SaveChangesAsync();

			return await _context.Address.ToListAsync();
		}

		public async Task<ActionResult<List<Address>>> PutAddress(int id, Address address)
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

				_context.Entry(address).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return await _context.Address.ToListAsync();
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

			return await _context.Address.ToListAsync();
		}
		private bool AddressExists(int id)
		{
			return _context.Address.Any(e => e.AddressId == id);
		}

	}
}
