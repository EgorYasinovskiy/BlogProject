using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Create
{
	public class CreateCommand : IRequest<Guid>
	{
		public string Name { get; set; }
	}
}
