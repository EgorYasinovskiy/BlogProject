using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.Tag.Commands.Change
{
	public class ChangeCommand : IRequest
	{
		public Guid TagId { get; set; }
	}
}
