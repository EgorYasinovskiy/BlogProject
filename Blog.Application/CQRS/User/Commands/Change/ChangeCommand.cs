using Blog.MQContract.Auth;
using MediatR;

namespace Blog.Application.CQRS.User.Commands.Change
{
	public class ChangeCommand : IRequest
	{
		public UserChange UserChange { get; set; }
	}
}
