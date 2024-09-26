using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class DbFactory : IDesignTimeDbContextFactory<Db> //scaffolding işlemleri için
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=StockTracking;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;");
            return new Db(optionsBuilder.Options);
        }
    }
}
