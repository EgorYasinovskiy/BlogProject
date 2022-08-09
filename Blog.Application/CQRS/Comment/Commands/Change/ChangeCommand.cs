using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Comment.Commands.Change
{
	public class ChangeCommand : IRequest<CommentViewModel>
	{
		public Guid CurrentUserId { get; set; }
		public Guid Id { get; set; }
		public string NewText { get; set; }
	}
}
