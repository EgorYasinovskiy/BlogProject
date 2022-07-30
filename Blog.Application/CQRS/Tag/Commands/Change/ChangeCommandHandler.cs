using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Tag.Commands.Change
{
	public class ChangeCommandHandler : IRequestHandler<ChangeCommand>
	{
		public Task<Unit> Handle(ChangeCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
