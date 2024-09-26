using Business.Models;
using Core.Repositories.EntityFramework.Bases;
using Core.Results;
using Core.Results.Bases;
using Core.Services.Bases;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IBlogService : IService<BlogModel>
    {

    }
    public class BlogService : IBlogService
    {
        private readonly RepoBase<Blog> _blogRepo;

        public BlogService(RepoBase<Blog> blogRepo)
        {
            _blogRepo = blogRepo;
        }
        public IQueryable<BlogModel> Query()
        {
            return _blogRepo.Query().OrderByDescending(b => b.CreateDate).ThenBy(b => b.Title).Select(b => new BlogModel()
            {
                Content = b.Content,
                CreateDate = b.CreateDate,
                Guid = b.Guid,
                Id = b.Id,
                Title = b.Title,
                Score = b.Score,
                UpdateDate = b.UpdateDate,
                UserId = b.UserId,

                UserNameDisplay = b.User.UserName,
                CreateDateDisplay = b.CreateDate.ToString("dd/MM/yyyy"),
                UpdateDateDisplay = b.UpdateDate.HasValue ? b.UpdateDate.Value.ToString("dd/MM/yyyy") : "",
                TagsDisplay = string.Join("<br />", b.BlogTags.Select(bt => bt.Tag.Name)),
            });
        }
        public Result Add(BlogModel model)
        {
            Blog entity = new Blog()
            {
                Content = model.Content,
                CreateDate = DateTime.Now,
                Score = model.Score,
                Title = model.Title,
                UserId = model.UserId,

                BlogTags = model.TagIds.Select(tagId => new BlogTag()
                {
                    TagId = tagId,
                }).ToList(),
            };

            _blogRepo.Add(entity);

            return new SuccessResult("Blod added successfully");
        }

        public Result Update(BlogModel model)
        {
            throw new NotImplementedException();
        }
        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _blogRepo.Dispose();
        }
    }
}
