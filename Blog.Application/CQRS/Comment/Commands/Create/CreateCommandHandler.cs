using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Comment.Commands.Create
{
	public class CreateCommandHandler : IRequestHandler<CreateCommand, CommentViewModel>
	{
		private readonly IDataContext _context;
		private readonly IMapper _mapper;

		public CreateCommandHandler(IDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<CommentViewModel> Handle(CreateCommand request, CancellationToken cancellationToken)
		{
			Model.PostItem post;
			if ((post = await _context.Posts.FindAsync(request.PostId, cancellationToken)) == null)
				throw new EntityNotFoundException(nameof(Model.PostItem), request.PostId);

			var comment = new Model.Comment()
			{
				AuthorID = request.AuthorId,
				Post = post,
				PostId = post.Id,
				Text = request.Text,
				Created = DateTime.Now,
				Id = Guid.NewGuid()
			};

			await _context.Comments.AddAsync(comment);
			comment = await _context.Comments
				.Include(x => x.Author)
				.FirstAsync(x => x.Id == comment.Id, cancellationToken);

			return _mapper.Map<CommentViewModel>(comment);
		}
	}
}
