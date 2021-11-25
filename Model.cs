1.	using System;
2.	using System.Collections.Generic;
3.	using Microsoft.EntityFrameworkCore;
4.	 
5.	namespace EFGetStarted
6.	{
7.	    public class BloggingContext : DbContext
8.	    {
9.	        public DbSet<Blog> Blogs { get; set; }
10.	        public DbSet<Post> Posts { get; set; }
11.	 
12.	        public string DbPath { get; private set; }
13.	 
14.	        public BloggingContext()
15.	        {
16.	            var folder = Environment.SpecialFolder.LocalApplicationData;
17.	            var path = Environment.GetFolderPath(folder);
18.	            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
19.	        }
20.	 
21.	        // The following configures EF to create a Sqlite database file in the
22.	        // special "local" folder for your platform.
23.	        protected override void OnConfiguring(DbContextOptionsBuilder options)
24.	            => options.UseSqlite($"Data Source={DbPath}");
25.	    }
26.	 
27.	    public class Blog
28.	    {
29.	        public int BlogId { get; set; }
30.	        public string Url { get; set; }
31.	 
32.	        public List<Post> Posts { get; } = new List<Post>();
33.	    }
34.	 
35.	    public class Post
36.	    {
37.	        public int PostId { get; set; }
38.	        public string Title { get; set; }
39.	        public string Content { get; set; }
40.	 
41.	        public int BlogId { get; set; }
42.	        public Blog Blog { get; set; }
43.	    }
44.	}
