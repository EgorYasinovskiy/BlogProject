using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Post.Commands.Change
{
	public class ChangeCommand : IRequest<PostViewModel>
	{
		public Guid CurrentUserId { get; set; }
		public Guid Id { get; set; }
		public string MarkDown { get; set; }
		public string Title { get; set; }
		public IEnumerable<string> Tags { get; set; }
	}
}
