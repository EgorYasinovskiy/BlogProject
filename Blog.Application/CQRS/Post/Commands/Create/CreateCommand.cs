using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Post.Commands.Create
{
	public class CreateCommand : IRequest<PostViewModel>
	{
		public Guid AuthorId { get; set; }
		public string Title { get; set; }
		public string MarkDown { get; set; }
		public IEnumerable<string> Tags { get; set; }

	}
}
