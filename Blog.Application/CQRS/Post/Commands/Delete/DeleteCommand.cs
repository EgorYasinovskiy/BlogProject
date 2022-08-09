using MediatR;

namespace Blog.Application.CQRS.Post.Commands.Delete
{
	public class DeleteCommand : IRequest
	{
		public Guid CurrentUserId { get; set; }
		public Guid PostId { get; set; }
	}
}
