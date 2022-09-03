using Blog.MQContract.Auth;
using MediatR;

namespace Blog.Application.CQRS.User.Commands.Create
{
	public class CreateCommand : IRequest
	{
		public UserCreate UserCreate { get; set; }
	}
}
