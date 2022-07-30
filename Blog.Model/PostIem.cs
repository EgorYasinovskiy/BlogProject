namespace Blog.Model
{
	public class PostItem
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string MarkDown { get; set; }
		public virtual ICollection<Tag> Tags { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Guid> Likes { get; set; }
		public Guid AuthorId { get; set; }
		public virtual User Author { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Edited { get; set; }
	}
}