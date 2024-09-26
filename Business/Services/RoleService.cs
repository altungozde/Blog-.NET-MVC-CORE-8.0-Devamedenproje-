using Business.Models;
using Core.Repositories.EntityFramework.Bases;
using Core.Results.Bases;
using Core.Services.Bases;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IRoleService : IService<RoleModel>
    {

    }
    public class RoleService : IRoleService
    {
        private readonly RepoBase<Role> _roleBase;

        public RoleService(RepoBase<Role> roleBase)
        {
            _roleBase = roleBase;
        }

        public IQueryable<RoleModel> Query()
        {
            throw new NotImplementedException();
        }

        public Result Add(RoleModel model)
        {
            throw new NotImplementedException();
        }
        public Result Update(RoleModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _roleBase.Dispose();
        }
    }
}
