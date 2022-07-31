using AutoMapper;
using Blog.Application.Contract.Interfaces;

namespace Blog.Application.Mappings.DTO
{
	public class PostListItemViewModel : IMapWith<Model.PostItem>
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public int LikesCount { get; set; }
		public int CommentsCount { get; set; }
		public DateTime Created { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Model.PostItem, PostListItemViewModel>()
				.ForMember(x => x.Id, opt => opt.MapFrom(mod => mod.Id))
				.ForMember(x => x.Title, opt => opt.MapFrom(mod => mod.Title))
				.ForMember(x => x.LikesCount, opt => opt.MapFrom(mod => mod.Likes.Count))
				.ForMember(x => x.CommentsCount, opt => opt.MapFrom(mod => mod.Comments.Count))
				.ForMember(x => x.Created, opt => opt.MapFrom(mod => mod.Created));
		}
	}
}
