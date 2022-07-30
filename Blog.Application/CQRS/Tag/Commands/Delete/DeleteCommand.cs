using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Delete
{
	public class DeleteCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
