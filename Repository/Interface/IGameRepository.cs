using System.Collections.Generic;
using Repository.Schema;

namespace Repository.Interface
{
    public interface IGameRepository
    {
        int Insert(GameModel obj);
        List<GameModel> SelectList();
    }
}
