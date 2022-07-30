using Blog.Application.Exceptions;
using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Change
{
	public class ChangeCommandHandler : IRequestHandler<ChangeCommand>
	{
		private readonly IDataContext _dataContext;

		public ChangeCommandHandler(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<Unit> Handle(ChangeCommand request, CancellationToken cancellationToken)
		{
			var tag = await _dataContext.Tags.FindAsync(request.TagId, cancellationToken);
			if (tag == null)
				throw new EntityNotFoundException(nameof(Model.Tag), request.TagId);
			tag.Name = request.NewName;
			await _dataContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
