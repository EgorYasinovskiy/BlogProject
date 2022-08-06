using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Post.Requests.GetByTag
{
	public class GetByTagRequestHandler : IRequestHandler<GetByTagRequest, PostListViewModel>
	{
		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public GetByTagRequestHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}
		public async Task<PostListViewModel> Handle(GetByTagRequest request, CancellationToken cancellationToken)
		{
			var posts = await _dataContext.Posts
				.Where(x => x.Tags.Any(y => y.Id == request.TagId))
				.ProjectTo<PostListItemViewModel>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return new PostListViewModel() { Posts = posts };
		}
	}
}
