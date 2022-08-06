namespace Blog.Model
{
	public class Tag
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<PostItem> Posts { get; set; }
	}
}
