namespace Blog.Application.Exceptions
{
	internal class EntityDoublicateException : Exception
	{
		public string EntityName { get; }
		public object DoublicateKey { get; }
		public EntityDoublicateException(string entityName, object doublicateKey)
			: base($"Entity doublicate. Entity name - \"{entityName}\". Doublicate key - \"{doublicateKey}\"")
		{
			EntityName = entityName;
			DoublicateKey = doublicateKey;
		}

	}
}
