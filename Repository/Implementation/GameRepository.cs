using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Repository.Interface;
using Repository.Schema;

namespace Repository.Implementation
{
    public class GameRepository : IGameRepository
    {
        public GameRepository()
        {
            new DapperHelper();
        }

        public int Insert(GameModel obj)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<int>(
                        "sp_insert_game",
                        new { obj.GameTypeId, obj.PlayerId },
                        commandType: CommandType.StoredProcedure)
                    .Single();
            }
        }

        public List<GameModel> SelectList()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<GameModel>(
                        "sp_select_list_game",
                        commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }
    }
}
