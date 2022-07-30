using Blog.Application.Mappings.DTO;
using MediatR;

namespace Blog.Application.CQRS.Tag.Requests.GetList
{
	public class GetListRequest : IRequest<TagListViewModel>
	{

	}
}
