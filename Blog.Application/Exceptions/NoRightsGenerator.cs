namespace Blog.Application.Exceptions
{
	public static class NoRightsGenerator
	{
		public static NotAuthorizedException DeleteException(Guid entity, Guid user)
		{
			return new NotAuthorizedException("delete", entity, user);
		}

		public static NotAuthorizedException ChangeException(Guid entity, Guid user)
		{
			return new NotAuthorizedException("change", entity, user);
		}
	}
}
