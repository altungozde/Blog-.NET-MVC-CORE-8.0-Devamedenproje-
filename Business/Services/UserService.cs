using Business.Models;
using Core.Repositories.EntityFramework.Bases;
using Core.Results.Bases;
using Core.Services.Bases;
using DataAccess.Entities;
    
namespace Business.Services
{
    
    public interface IUserService : IService<UserModel>
    {

    }
    public class UserService : IUserService
    {
        private readonly RepoBase<User> _userRepo;

        public UserService(RepoBase<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public IQueryable<UserModel> Query()
        {
            return _userRepo.Query().OrderByDescending(u => u.IsActive).ThenBy(u => u.UserName).Select(u => new UserModel()
            {
                UserName = u.UserName,
                Guid = u.Guid,
                Id = u.Id,
                IsActive = u.IsActive,
                Password = u.Password,
                RoleId = u.RoleId
            });
        }
        public Result Add(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Result Update(UserModel model)
        {
            throw new NotImplementedException();
        }
        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _userRepo.Dispose();
        }
    }
}
