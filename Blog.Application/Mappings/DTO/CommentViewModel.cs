using AutoMapper;
using Blog.Application.Contract.Interfaces;

namespace Blog.Application.Mappings.DTO
{
	public class CommentViewModel : IMapWith<Model.Comment>
	{
		public string UserName { get; set; }
		public string Comment { get; set; }
		public DateTime Created { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Model.Comment, CommentViewModel>()
				.ForMember(vm => vm.UserName, opt => opt.MapFrom(mod => mod.Author.Username))
				.ForMember(vm => vm.Comment, opt => opt.MapFrom(mod => mod.Text))
				.ForMember(vm => vm.Created, opt => opt.MapFrom(mod => mod.Created));
		}
	}
}
