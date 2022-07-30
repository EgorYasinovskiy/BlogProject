namespace Blog.Model
{
	public class Comment
	{
		public Guid Id { get; set; }
		public string Text { get; set; }
		public Guid AuthorID { get; set; }
		public virtual User Author { get; set; }
		public Guid PostId { get; set; }
		public DateTime Created { get; set; }
		public virtual PostItem Post { get; set; }
	}
}