using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Comment.Commands.Create
{
	public class CreateCommand : IRequest<CommentViewModel>
	{
		public Guid AuthorId { get; set; }
		public Guid PostId { get; set; }
		public string Text { get; set; }

	}
}
