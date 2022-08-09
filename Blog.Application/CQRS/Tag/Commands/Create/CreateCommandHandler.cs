using AutoMapper;
using Blog.Application.Exceptions;
using Blog.Application.Mappings.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.CQRS.Tag.Commands.Create
{
	public class CreateCommandHandler : IRequestHandler<CreateCommand, TagViewModel>
	{

		private readonly IDataContext _dataContext;
		private readonly IMapper _mapper;

		public CreateCommandHandler(IDataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}
		public async Task<TagViewModel> Handle(CreateCommand request, CancellationToken cancellationToken)
		{
			Model.Tag tag = await _dataContext.Tags.
				FirstOrDefaultAsync(x => x.Name.Equals(request.Name, StringComparison.CurrentCultureIgnoreCase), cancellationToken);
			if (tag != null)
				throw new EntityDoublicateException(nameof(Model.Tag), tag.Id);
			tag = new Model.Tag() { Id = Guid.NewGuid(), Name = request.Name };
			var result = await _dataContext.Tags.AddAsync(tag, cancellationToken);
			await _dataContext.SaveChangesAsync(cancellationToken);
			tag = await _dataContext.Tags
				.Include(x => x.Posts)
				.FirstAsync(x => x.Id == tag.Id, cancellationToken);
			return _mapper.Map<TagViewModel>(tag);
		}
	}
}
