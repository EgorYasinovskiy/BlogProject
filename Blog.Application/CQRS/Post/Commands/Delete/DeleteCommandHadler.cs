using Blog.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Post.Commands.Delete
{
	public class DeleteCommandHadler : IRequestHandler<DeleteCommand>
	{
		private readonly IDataContext _context;

		public DeleteCommandHadler(IDataContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
		{
			var post = await _context.Posts.FindAsync(request.PostId, cancellationToken);
			if (post == null)
				throw new EntityNotFoundException(nameof(Model.PostItem), request.PostId);
			_context.Posts.Remove(post);
			await _context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
