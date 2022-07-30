using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Change
{
	public class ChangeCommand : IRequest
	{
		public Guid TagId { get; set; }
		public string NewName { get; set; }
	}
}
