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
             *  �⽫��װdotnet ef������Ŀ�����������������ư����������Ǩ���Դ���ģ�͵ĳ�ʼ��������������ݿ⣬��Ӧ���µ�Ǩ�ơ�
             *  dotnet tool install --global dotnet-ef
                dotnet add package Microsoft.EntityFrameworkCore.Design
                dotnet ef migrations add InitialCreate
                dotnet ef database update
             * 
             * 
             * 
             */
            //���ֻ��һ���Դ�����֮��ִ���޸ĵģ�����ʹ�� EnsureCreated ��������
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
