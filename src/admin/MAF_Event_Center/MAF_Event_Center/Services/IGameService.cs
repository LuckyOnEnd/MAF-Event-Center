using MAF_Event_Center.Models.Game;
using MAF_Event_Center.SPA.Models;

namespace MAF_Event_Center.SPA.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAll();
        Task Delete(Guid id);
        Task CreateGame(CreateGame game);
    }
}
