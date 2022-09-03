using AutoMapper;
using MediatR;

namespace Blog.Application.CQRS.User.Commands.Create
{
	public class CreateCommandHandler : IRequestHandler<CreateCommand>
	{
		private readonly IDataContext _context;
		private readonly IMapper _mapper;
		public CreateCommandHandler(IDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
		{
			var reqUser = request.UserCreate;
			var user = _mapper.Map<Model.User>(reqUser);
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
