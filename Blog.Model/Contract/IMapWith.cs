using AutoMapper;

namespace Blog.Contract
{
	public interface IMapWith<T>
	{
		public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
	}
}
