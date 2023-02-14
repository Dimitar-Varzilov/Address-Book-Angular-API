using AddressBookAPI.Data;
using AddressBookAPI.Dtos;
using AddressBookAPI.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Net;

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

		public async Task<ActionResult<List<Address>>> GetTrimmedAddressesAsync(int count, string query)
		{
			//var results = await _context.Address.ContainsAsync();
			var predicate = (Address item) => {
				AddressDto addressDto = _mapper.Map<AddressDto>(item);
				return addressDto.ToString().Contains(query.Trim().ToLower());
			};
			var results2 = await _context.Address.Where(predicate);
			//await _context.Address.Where()
			//Console.WriteLine(results2.);
			List <Address> trimmed5addresses = await _context.Address.ToListAsync();
			var filteredResults = trimmed5addresses.FindAll(listItem =>
			{
				AddressDto mappedItem = _mapper.Map<AddressDto>(listItem);
				return mappedItem.ToJson().Contains(query);
			}
			);
			Paginator paginator = new(filteredResults, count);
			var addressessDto = paginator.GetPagesList().Select(address => _mapper.Map<AddressDto>(address));
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
