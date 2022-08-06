using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Post.Requests.Get
{
	public class GetRequestHandler : IRequestHandler<GetRequest, PostViewModel>
	{
		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public GetRequestHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}
		public async Task<PostViewModel> Handle(GetRequest request, CancellationToken cancellationToken)
		{
			var post = await _dataContext.Posts.FirstOrDefaultAsync(x => x.Id == request.ID, cancellationToken);
			if (post == null)
				throw new EntityNotFoundException(nameof(Model.PostItem), request.ID);
			var dto = _mapper.Map<PostViewModel>(post);
			return dto;

		}
	}
}
