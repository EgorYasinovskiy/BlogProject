using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Post.Requests.GetByTag
{
	public class GetByTagRequest : IRequest<PostListViewModel>
	{
		public Guid TagId { get; set; }
	}
}
