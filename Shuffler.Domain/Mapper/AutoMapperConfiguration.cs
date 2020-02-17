namespace Shuffler.Domain
{
	public static class AutoMapperConfiguration
	{
		public static void Configure()
		{
			global::AutoMapper.Mapper.Initialize(config => config.AddProfile(new AutoMapperProfile()));
		}
	}
}
