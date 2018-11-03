using Repository.Schema;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IPlayerRepository
    {
        int Insert(PlayerModel obj);
        List<PlayerModel> SelectList();
        PlayerModel Select(int id);
    }
}
