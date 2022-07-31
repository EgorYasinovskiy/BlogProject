using AutoMapper;
using Blog.Application.Mappings.DTO;
using Blog.Model;

namespace Blog.Application.Mappings.Converters
{
	public class PostToPostViewModelTypeConverter : ITypeConverter<PostItem, PostViewModel>
	{
		public PostViewModel Convert(PostItem source, PostViewModel destination, ResolutionContext context)
		{
			var tags = source.Tags != null ? context.Mapper.Map<List<TagViewModel>>(source.Tags?.ToList()) : null;
			var comments = source.Comments != null ? context.Mapper.Map<List<CommentViewModel>>(source.Comments?.ToList()) : null;

			destination = new PostViewModel
			{
				Id = source.Id,
				MarkDown = source.MarkDown,
				Likes = source.Likes,
				Title = source.Title,
				Tags = tags,
				Comments = comments
			};
			return destination;
		}
	}
}
