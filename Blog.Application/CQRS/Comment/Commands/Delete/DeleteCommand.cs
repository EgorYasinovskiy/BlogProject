using MediatR;

namespace Blog.Application.CQRS.Comment.Commands.Delete
{
	public class DeleteCommand : IRequest
	{
		public Guid CurrentUserId { get; set; }
		public Guid CommentId { get; set; }
	}
}
