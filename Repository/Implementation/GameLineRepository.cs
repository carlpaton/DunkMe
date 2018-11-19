using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Repository.Interface;
using Repository.Schema;

namespace Repository.Implementation
{
    public class GameLineRepository : IGameLineRepository
    {
        public int Insert(GameLineModel obj)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<int>(
                        "sp_insert_game_line",
                        new { obj.GameId, obj.Score },
                        commandType: CommandType.StoredProcedure)
                    .Single();
            }
        }

        public List<GameLineModel> SelectListByGameId(int id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<GameLineModel>(
                        "sp_select_list_game_line",
                        new { GameId = id },
                        commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }
    }
}
