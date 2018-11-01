using Repository.Schema;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IGameTypeRepository
    {
        int Insert(GameTypeModel obj);
        List<GameTypeModel> SelectList();
    }
}
