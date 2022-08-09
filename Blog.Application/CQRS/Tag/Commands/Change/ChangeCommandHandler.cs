using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Change
{
	public class ChangeCommandHandler : IRequestHandler<ChangeCommand,TagViewModel>
	{
		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public ChangeCommandHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

		public async Task<TagViewModel> Handle(ChangeCommand request, CancellationToken cancellationToken)
		{
			var tag = await _dataContext.Tags.FindAsync(request.TagId, cancellationToken);
			if (tag == null)
				throw new EntityNotFoundException(nameof(Model.Tag), request.TagId);
			tag.Name = request.NewName;

			_dataContext.Tags.Update(tag);
			await _dataContext.SaveChangesAsync(cancellationToken);

			return _mapper.Map<TagViewModel>(tag);
		}
	}
}
