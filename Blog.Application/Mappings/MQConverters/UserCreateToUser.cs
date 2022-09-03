using AutoMapper;
using Blog.Application.Contract.Interfaces;

namespace Blog.Application.Mappings.MQConverters
{
	public class UserCreateToUser : IMapWith<Model.User>
	{
		public void Mapping(Profile profile)
		{
			profile.CreateMap<MQContract.Auth.UserCreate, Model.User>()
				.ForMember(x => x.Id, opt => opt.MapFrom(mod => mod.Id))
				.ForMember(x => x.Email, opt => opt.MapFrom(mod => mod.Email))
				.ForMember(x => x.FirstName, opt => opt.MapFrom(mod => mod.FirstName))
				.ForMember(x => x.LastName, opt => opt.MapFrom(mod => mod.LastName))
				.ForMember(x => x.UserName, opt => opt.MapFrom(mod => mod.UserName))
				.ForMember(x => x.Gender, opt => opt.MapFrom(mod => mod.Gender));
		}
	}
}
