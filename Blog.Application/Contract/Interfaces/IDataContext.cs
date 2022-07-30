﻿using Blog.Model;
using Microsoft.EntityFrameworkCore;

public interface IDataContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<PostItem> Posts { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Tag> Tags { get; set; }
	public int SaveChanges();
	public int SaveChanges(bool acceptAllChangesOnSucces);
	public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
	public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}