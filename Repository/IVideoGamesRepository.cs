using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDVideoGamesApp.Repository
{
    public interface IVideoGamesRepository<T>
    {
        Task<IEnumerable<T>> GetVideoGames();
        Task<IEnumerable<T>> GetEntityById(string spname, int id);
        Task DeleteEntities(string spname, int id);
    }
}