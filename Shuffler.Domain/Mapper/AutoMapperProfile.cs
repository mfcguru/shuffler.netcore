using AutoMapper;
using System;

namespace Shuffler.Domain
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Card, CardDto>()
				.ForMember(dest => dest.Key, src => src.MapFrom(o => Guid.NewGuid()))
				.ForMember(dest => dest.ImageUrl, src => src.MapFrom(o => string.Format("/img/{0}.png", o.ImageFilename)));
		}
	}
}
