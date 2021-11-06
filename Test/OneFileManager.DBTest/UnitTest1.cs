using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneFileManager.DB;
using System;
using System.Linq;

namespace OneFileManager.DBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /**
             *  
             *  这将安装dotnet ef和在项目上运行命令所需的设计包。命令基架迁移以创建模型的初始表集。该命令创建数据库，并应用新的迁移。
             *  dotnet tool install --global dotnet-ef
                dotnet add package Microsoft.EntityFrameworkCore.Design
                dotnet ef migrations add InitialCreate
                dotnet ef database update
             * 
             * 
             * 
             */
            //如果只是一次性创建，之后不执行修改的，可以使用 EnsureCreated 函数创建
            // using (var BloggingContext = new BloggingContext())
            //{
            //    BloggingContext.Database.EnsureCreated();
            //}

            //  using (var BloggingContext = new BloggingContext())
            //{
            //    BloggingContext.Database.Migrate();
            //}


            // using (var db = new SQLLite3Context())
            //{
            //    // Create
            //    Console.WriteLine("Inserting a new blog");
            //    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            //    db.SaveChanges();

            //    // Read
            //    Console.WriteLine("Querying for a blog");
            //    var blog = db.Blogs
            //        .OrderBy(b => b.BlogId)
            //        .First();

            //    // Update
            //    Console.WriteLine("Updating the blog and adding a post");
            //    blog.Url = "https://devblogs.microsoft.com/dotnet";
            //    blog.Posts.Add(
            //        new Post
            //        {
            //            Title = "Hello World",
            //            Content = "I wrote an app using EF Core!"
            //        });
            //    db.SaveChanges();

            //    // Delete
            //    Console.WriteLine("Delete the blog");
            //    db.Remove(blog);
            //    db.SaveChanges();
            //}
        }
    }
}
