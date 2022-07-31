using AutoMapper;
using Blog.Application.Contract.Interfaces;
using Blog.Application.Mappings.Converters;

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
				.ConvertUsing<PostToPostViewModelTypeConverter>();
		}
	}
}
