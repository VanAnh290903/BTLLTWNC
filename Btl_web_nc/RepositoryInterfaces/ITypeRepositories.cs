using Btl_web_nc.Models;
namespace Btl_web_nc.RepositoryInterfaces
{
    public interface ITypeRepositories
    {
        public long GetTypeByName(string typeName);
        public Btl_web_nc.Models.Type GetTypeById(long typeId);
    }
}
