using AddressBookAPI.Dtos;
using AutoMapper;

namespace AddressBookAPI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Address , AddressDto>();
		}
	}
}
