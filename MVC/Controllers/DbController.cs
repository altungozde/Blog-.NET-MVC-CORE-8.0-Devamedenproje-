using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MVC.Controllers
{
    public class DbController : Controller
    {
        private readonly Db _db;

        public DbController(Db db)
        {
            _db = db;
        }

        public IActionResult Seed()
        {
            #region Delete

            var blogTags =_db.BlogTags.ToList();
            _db.BlogTags.RemoveRange(blogTags);

            var tags = _db.Tags.ToList();
            _db.Tags.RemoveRange(tags);

            var users = _db.Users.ToList();
            _db.Users.RemoveRange(users);

            var roles = _db.Roles.ToList();
            _db.Roles.RemoveRange(roles);

            if (roles.Count > 0) // eğer veritabanında rol kaydı varsa eklenecek rollerin rol id'lerini aşağıdaki SQL komutu üzerinden 1'den başlayacak hale getiriyoruz
                                 // eğer kayıt yoksa o zaman zaten rol tablosuna daha önce veri eklenmemiştir dolayısıyla rol id'leri 1'den başlayacaktır
            {
                _db.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Roles', RESEED, 0)"); // ExecuteSqlRaw methodu üzerinden istenilen SQL sorgusu elle yazılıp veritabanında çalıştırılabilir
            }

            var blogs = _db.Blogs.ToList();
            _db.Blogs.RemoveRange(blogs);

            _db.SaveChanges();

            #endregion

            #region insert
            _db.Roles.Add(new Role()
            {
                Name = "Admin",
                Users = new List<User>()
                {
                    new User()
                    {
                        UserName = "admin",
                        Password = "admin",
                        IsActive = true,
                    }
                }
            });

            _db.Roles.Add(new Role()
            {
                Name = "User",
                Users = new List<User>()
                {
                    new User()
                    {
                        UserName = "user",
                        Password = "user",
                        IsActive = true,
                    }
                }
            });

            _db.Tags.Add(new Tag()
            {
                Name = "Programming",
                IsPopular = true,
            });
            _db.Tags.Add(new Tag()
            {
                Name = "Technology",
                IsPopular = true,
            });

            _db.Tags.Add(new Tag()
            {
                Name = "Social Media",
                IsPopular = true,
            });

            _db.Tags.Add(new Tag()
            {
                Name = "Book",
            });

            _db.Tags.Add(new Tag()
            {
                Name = "Music",
                IsPopular = true,
            });

            _db.SaveChanges();

            _db.Blogs.Add(new Blog()
            {
                Title = "Visual Studio Code",
                Content = "Developing applications using Visual Studio Code",
                CreateDate = DateTime.Now,
                Score = 5,
                UserId = _db.Users.SingleOrDefault(u => u.UserName == "admin").Id,
                BlogTags = new List<BlogTag>()
                {
                    new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Programming").Id,
                    },
                    new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Technology").Id,
                    }
                }
            });

            _db.Blogs.Add(new Blog()
            {
                Title = "White Fand",
                Content = "One of  Jack London's popular book",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Score = 4,
                UserId = _db.Users.SingleOrDefault(u => u.UserName == "admin").Id,
                BlogTags = new List<BlogTag>()
                {
                    new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Book").Id,
                    },
                }
            });

            _db.Blogs.Add(new Blog()
            {
                Title = "We Are The Champions",
                Content = "One of the Queen's popular music",
                CreateDate = DateTime.Now,
                UpdateDate= DateTime.Now,
                Score = 4,
                UserId = _db.Users.SingleOrDefault(u => u.UserName == "user").Id,
                BlogTags = new List<BlogTag>()
                {
                    new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Music").Id,
                    },
                 
                }
            });
            _db.Blogs.Add(new Blog()
            {
                Title = "Instagram",
                Content = "On of the biggest social network",
                CreateDate = DateTime.Now,
                Score = 5,
                UserId = _db.Users.SingleOrDefault(u => u.UserName == "user").Id,
                BlogTags = new List<BlogTag>()
                {
                    new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Programming").Id,
                    },
                    new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Technology").Id,
                    },
                     new BlogTag()
                    {
                        TagId = _db.Tags.SingleOrDefault(t => t.Name == "Social Media").Id,
                    }
                }
            });

            _db.SaveChanges();

            #endregion

            //return Content("<p style=\" color:red;font-weight:bold;\">Database seed successful.</p>", "text/html", Encoding.UTF8);
            return View();            
        }
    }
}
