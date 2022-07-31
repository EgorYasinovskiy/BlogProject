using AutoMapper;
using Blog.Application.Contract.Interfaces;

namespace Blog.Application.Mappings.DTO
{
	public class PostViewModel : IMapWith<Model.PostItem>
	{
		public string Title { get; set; }
		public Guid Id { get; set; }
		public string MarkDown { get; set; }
		public ICollection<CommentViewModel> Comments { get; set; }
		public ICollection<TagViewModel> Tags { get; set; }
		public ICollection<Guid> Likes { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Model.PostItem, PostViewModel>()
				.ForMember(vm => Title, opt => opt.MapFrom(mod => mod.Title))
				.ForMember(vm => Id, opt => opt.MapFrom(mod => mod.Id))
				.ForMember(vm => MarkDown, opt => opt.MapFrom(mod => mod.MarkDown))
				.ForMember(vm => Comments, opt => opt.MapFrom(mod => ));
		}
	}
}
