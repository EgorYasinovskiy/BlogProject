using Blog.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Tag.Commands.Create
{
	public class CreateCommandHandler : IRequestHandler<CreateCommand, Guid>
	{

		private readonly IDataContext _dataContext;
		public CreateCommandHandler(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
		{
			Model.Tag tag = await _dataContext.Tags.FirstOrDefaultAsync(x => x.Name.Equals(request.Name, StringComparison.CurrentCultureIgnoreCase), cancellationToken);
			if (tag != null)
				throw new EntityDoublicateException(nameof(Model.Tag), tag.Id);
			tag = new Model.Tag() { Id = Guid.NewGuid(), Name = request.Name };
			var result = await _dataContext.Tags.AddAsync(tag, cancellationToken);
			await _dataContext.SaveChangesAsync(cancellationToken);
			return result.Entity.Id;
		}
	}
}
