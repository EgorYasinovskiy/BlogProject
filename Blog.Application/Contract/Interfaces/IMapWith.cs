using AutoMapper;

namespace Blog.Application.Contract.Interfaces
{
	public interface IMapWith<T>
	{
		public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
	}
}
