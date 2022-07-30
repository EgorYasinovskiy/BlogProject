using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Tag.Requests.Get
{
	public class GetTagRequest : IRequest<TagViewModel>
	{
		public Guid Id { get; set; }
	}
}
