namespace Blog.Application.Exceptions
{
	public class NotAuthorizedException : Exception
	{
		public NotAuthorizedException(string actionName, Guid entityId, Guid userId) 
			: base($"User with id {userId} have no right to {actionName} entity with id {entityId}")
		{

		}
	}
}
