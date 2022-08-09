using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Tag.Commands.Create
{
	public class CreateCommand : IRequest<TagViewModel>
	{
		public string Name { get; set; }
	}
}
