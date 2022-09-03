using Blog.MQContract.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.CQRS.User.Commands.Change
{
	public class ChangeCommand  : IRequest
	{
		public UserChange UserChange { get; set; }
	}
}
