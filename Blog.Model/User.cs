namespace Blog.Model
{
	public class User
	{
		public Guid Id { get; set; }
		public UserRole Role { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool Gender { get; set; }
		public string Bio { get; set; }
		public virtual ICollection<PostItem> Posts { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
	}
}
