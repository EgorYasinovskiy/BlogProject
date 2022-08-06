using MediatR;

namespace Blog.Application.CQRS.Post.Commands.Delete
{
	public class DeleteCommand : IRequest
	{
		public Guid PostId { get; set; }
	}
}
