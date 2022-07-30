using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Create
{
	public class CreateCommandHandler : IRequestHandler<CreateCommand, Guid>
	{
		public Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
