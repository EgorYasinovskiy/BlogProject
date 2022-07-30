using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Tag.Requests.Get
{
	public class GetTagRequestHandler : IRequestHandler<GetTagRequest, Mappings.DTO.TagViewModel>
	{
		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public GetTagRequestHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}
		public async Task<TagViewModel> Handle(GetTagRequest request, CancellationToken cancellationToken)
		{
			var tag = await _dataContext.Tags.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
			if (tag == null)
				throw new EntityNotFoundException(nameof(Tag), request.Id);
			var vm = _mapper.Map<TagViewModel>(tag);
			return vm;
		}
	}
}
