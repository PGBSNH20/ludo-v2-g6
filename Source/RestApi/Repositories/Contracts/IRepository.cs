using System.Threading.Tasks;

namespace RestApi.Repositories
{
    public interface IRepository
    {
        Task<T> Add<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task<bool> Save();
    }
}