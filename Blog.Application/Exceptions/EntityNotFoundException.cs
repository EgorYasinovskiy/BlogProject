namespace Blog.Application.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		public string EntityName { get; }
		public object Key { get; }
		public EntityNotFoundException(string entityName, object key) : base($"Entity \"{entityName}\" was not found by key - \"{key}\"")
		{
			EntityName = entityName;
			Key = key;
		}
	}
}
