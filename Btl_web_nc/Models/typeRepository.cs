using Btl_web_nc.RepositoryInterfaces;

namespace Btl_web_nc.Models
{
    public class TypeRepository:ITypeRepositories
    {
        private readonly AppDbContext _dbContext;
        public TypeRepository(AppDbContext db)
        {
            _dbContext = db;
        }
        public long GetTypeByName(string typeName)
        {
            Type type = _dbContext.Types.FirstOrDefault(t=> t.typeName==typeName);
            return type?.typeId ??0;
        }
        public Type GetTypeById(long typeId)
        {
            Type type = _dbContext.Types.FirstOrDefault(t=> t.typeId==typeId);
            return type;
        }
    }
}
