using Business.Models;
using Core.Repositories.EntityFramework.Bases;
using Core.Results.Bases;
using Core.Services.Bases;
using DataAccess.Entities;

namespace Business.Services
{
    public interface ITagService : IService<TagModel>
    {

    }
    public class TagService : ITagService
    {
        private readonly RepoBase<Tag> _tagRepo;

        public TagService(RepoBase<Tag> tagRepo)
        {
            _tagRepo = tagRepo;
        }
        public IQueryable<TagModel> Query()
        {
            return _tagRepo.Query().OrderBy(t => t.Name).Select(t => new TagModel()
            {
                Name = t.Name + (t.IsPopular? "*" : ""),
                Guid = t.Guid,
                Id = t.Id,
                IsPopular = t.IsPopular,

                IsPopularDisplay = t.IsPopular ? "Yes" : "No",
            });
        }
        public Result Add(TagModel model)
        {
            throw new NotImplementedException();
        }
        public Result Update(TagModel model)
        {
            throw new NotImplementedException();
        }
        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _tagRepo.Dispose();
        }    
    }
}
