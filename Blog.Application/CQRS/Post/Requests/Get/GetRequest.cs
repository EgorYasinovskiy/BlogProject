using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Post.Requests.Get
{
	public class GetRequest : IRequest<PostViewModel>
	{
		public Guid ID { get; set; }
	}
}
