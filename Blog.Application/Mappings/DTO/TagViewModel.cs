using AutoMapper;
using Blog.Application.Contract.Interfaces;

namespace Blog.Application.Mappings.DTO
{
	public class TagViewModel : IMapWith<Model.Tag>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Model.Tag, TagViewModel>()
				.ForMember(vm => vm.Name, opt => opt.MapFrom(mod => mod.Name))
				.ForMember(vm => vm.Id, opt => opt.MapFrom(mod => mod.Id));
		}
	}
}
