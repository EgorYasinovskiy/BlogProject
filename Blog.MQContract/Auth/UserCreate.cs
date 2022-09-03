namespace Blog.MQContract.Auth
{
	public class UserCreate
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public bool Gender { get; set; }
	}
}


