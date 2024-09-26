using Core.Records.Bases;
using Core.Repositories.EntityFramework.Bases;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class Repo<TEntitiy> : RepoBase<TEntitiy> where TEntitiy : Record, new()
    {
        public Repo(Db dbContext) : base(dbContext)
        {
        }
    }
}
