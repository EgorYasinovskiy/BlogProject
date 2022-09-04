using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Post.Commands.Change
{
	public class ChangeCommandHandler : IRequestHandler<ChangeCommand, PostViewModel>
	{
		private readonly IDataContext _context;
		private readonly IMapper _mapper;

		public ChangeCommandHandler(IDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<PostViewModel> Handle(ChangeCommand request, CancellationToken cancellationToken)
		{
			var post = await _context.Posts
				.Include(x => x.Author)
				.Include(x => x.Tags)
				.Include(x => x.Likes)
				.Include(x => x.Comments)
				.FirstAsync(x => x.Id == request.Id, cancellationToken);

			if (post == null)
				throw new EntityNotFoundException(nameof(Model.PostItem), request.Id);
			if (post.AuthorId != request.CurrentUserId)
				throw NoRightsGenerator.ChangeException(request.Id, request.CurrentUserId);

			post.Edited = DateTime.Now;
			post.Title = request.Title;
			post.MarkDown = request.MarkDown;

			var tagsSet = request.Tags.Select(x => x.ToLower()).ToHashSet();
			var tags = await _context.Tags.
				Where(x => tagsSet.Contains(x.Name.ToLower()))
				.ToListAsync(cancellationToken);

			post.Tags = tags;

			_context.Posts.Update(post);
			await _context.SaveChangesAsync(cancellationToken);

			return _mapper.Map<PostViewModel>(post);
		}
	}
}
