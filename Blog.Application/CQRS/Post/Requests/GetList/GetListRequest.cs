using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Post.Requests.GetList
{
	public class GetListRequest : IRequest<PostListViewModel>
	{

	}
}
