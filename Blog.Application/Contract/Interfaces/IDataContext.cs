using Blog.Model;
using Microsoft.EntityFrameworkCore;

public interface IDataContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<PostItem> Posts { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Tag> Tags { get; set; }
}