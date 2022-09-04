using Blog.Application.Exceptions;
using MediatR;

namespace Blog.Application.CQRS.User.Commands.Change
{
	public class ChangeCommandHandler : IRequestHandler<ChangeCommand>
	{
		private readonly IDataContext _context;

		public ChangeCommandHandler(IDataContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(ChangeCommand request, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FindAsync(request.UserChange.Id, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException(nameof(Model.User), request.UserChange.Id);

			var reqUser = request.UserChange;
			user.UserName = reqUser.UserName;
			user.Bio = reqUser.Bio;
			user.Gender = reqUser.Gender;
			user.FirstName = reqUser.FirstName;
			user.LastName = reqUser.LastName;
			_context.Users.Update(user);
			await _context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}
