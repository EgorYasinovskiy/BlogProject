namespace Blog.Model
{
	public class User
	{
		public Guid ID { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public bool Gender { get; set; }
		public string Bio { get; set; }
		public virtual ICollection<PostItem> Posts { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
	}
}
