namespace Blog.MQContract.Auth
{
	public class UserChange
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public bool Gender { get; set; }
		public string Bio { get; set; }
	}
}
