using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Tag.Requests.GetList
{
	public class GetListRequestHandler : IRequestHandler<GetListRequest, TagListViewModel>
	{
		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public GetListRequestHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}
		public async Task<TagListViewModel> Handle(GetListRequest request, CancellationToken cancellationToken)
		{
			var tags = await _dataContext.Tags.ProjectTo<TagViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
			return new TagListViewModel() { Tags = tags };
		}
	}
}
