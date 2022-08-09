using AutoMapper;
using Blog.Application.Exceptions;
using MediatR;

namespace Blog.Application.CQRS.Comment.Commands.Delete
{
	public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
	{
		private readonly IDataContext _context;
		private readonly IMapper _mapper;

		public DeleteCommandHandler(IDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
		{
			var comment = await _context.Comments.FindAsync(request.CommentId, cancellationToken);
			if (comment == null)
				throw new EntityNotFoundException(nameof(Model.Comment), request.CommentId);
			if (comment.AuthorID != request.CurrentUserId)
				throw NoRightsGenerator.DeleteException(request.CommentId, request.CurrentUserId);
			_context.Comments.Remove(comment);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
