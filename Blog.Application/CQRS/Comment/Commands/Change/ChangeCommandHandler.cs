using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Comment.Commands.Change
{
	public class ChangeCommandHandler : IRequestHandler<ChangeCommand, CommentViewModel>
	{
		private readonly IDataContext _context;
		private readonly IMapper _mapper;

		public ChangeCommandHandler(IDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<CommentViewModel> Handle(ChangeCommand request, CancellationToken cancellationToken)
		{
			var comment = await _context.Comments.FindAsync(request.Id, cancellationToken);

			if (comment == null)
				throw new EntityNotFoundException(nameof(Model.Comment), request.Id);
			if (comment.AuthorID != request.CurrentUserId)
				throw NoRightsGenerator.ChangeException(request.Id, request.CurrentUserId);

			comment.Text = request.NewText;
			_context.Comments.Update(comment);
			await _context.SaveChangesAsync(cancellationToken);

			return _mapper.Map<CommentViewModel>(comment);
		}
	}
}
