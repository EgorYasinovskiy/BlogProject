using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Change
{
	public class ChangeCommand : IRequest<TagViewModel>
	{
		public Guid TagId { get; set; }
		public string NewName { get; set; }
	}
}
