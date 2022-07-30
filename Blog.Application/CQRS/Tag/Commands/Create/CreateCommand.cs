using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Tag.Commands.Create
{
	public class CreateCommand : IRequest<Guid>
	{
		public string Name { get; set; }
	}
}
