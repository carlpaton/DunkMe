using System.Collections.Generic;
using Repository.Schema;

namespace Repository.Interface
{
    public interface IGameLineRepository
    {
        int Insert(GameLineModel obj);
        List<GameLineModel> SelectListByGameId(int id);
    }
}
