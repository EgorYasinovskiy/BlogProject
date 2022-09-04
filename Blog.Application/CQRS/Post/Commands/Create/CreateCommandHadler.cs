using AutoMapper;
using Blog.Application.Mappings.DTO;
using Blog.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Post.Commands.Create
{
	public class CreateCommandHadler : IRequestHandler<CreateCommand, PostViewModel>
	{
		private readonly IDataContext _context;
		private readonly IMapper _mapper;

		public CreateCommandHadler(IDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<PostViewModel> Handle(CreateCommand request, CancellationToken cancellationToken)
		{
			var tagsSet = request.Tags.Select(x => x.ToLower()).ToHashSet();
			var tags = _context.Tags.Where(x => tagsSet.Contains(x.Name.ToLower()));
			var post = new PostItem()
			{
				AuthorId = request.AuthorId,
				Title = request.Title,
				MarkDown = request.MarkDown,
				Tags = await tags.ToListAsync()
			};
			await _context.Posts.AddAsync(post, cancellationToken);
			post = await _context.Posts
				.Include(x => x.Author)
				.FirstAsync(x => x.Id == post.Id, cancellationToken);

			return _mapper.Map<PostViewModel>(post);
		}
	}
}
