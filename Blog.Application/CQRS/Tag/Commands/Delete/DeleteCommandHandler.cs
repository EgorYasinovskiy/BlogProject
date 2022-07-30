using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Tag.Commands.Delete
{
	public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
	{
		public Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
