using Blog.Application.Exceptions;
using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Delete
{
	public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
	{
		private readonly IDataContext _dataContext;

		public DeleteCommandHandler(IDataContext context)
		{
			_dataContext = context;
		}

		public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
		{
			var tag = await _dataContext.Tags.FindAsync(request.Id, cancellationToken);
			if (tag == null)
				throw new EntityNotFoundException(nameof(Model.Tag), request.Id);
			_dataContext.Tags.Remove(tag);
			await _dataContext.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}
