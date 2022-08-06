using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Post.Requests.GetList
{
	public class GetListRequestHandler : IRequestHandler<GetListRequest, PostListViewModel>
	{
		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public GetListRequestHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}
		public async Task<PostListViewModel> Handle(GetListRequest request, CancellationToken cancellationToken)
		{
			var posts = await _dataContext.Posts.ProjectTo<PostListItemViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
			return new PostListViewModel() { Posts = posts };
		}
	}
}
