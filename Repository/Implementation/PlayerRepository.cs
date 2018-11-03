using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Repository.Interface;
using Repository.Schema;

namespace Repository.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository()
        {
            new DapperHelper();
        }

        public int Insert(PlayerModel obj)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<int>(
                        "sp_insert_player",
                        new { obj.Email },
                        commandType: CommandType.StoredProcedure)
                    .Single();
            }
        }

        public PlayerModel Select(int id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<PlayerModel>(
                        "sp_select_player_by_id",
                        new { id },
                        commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
        }

        public List<PlayerModel> SelectList()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<PlayerModel>(
                        "sp_select_list_player",
                        commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }
    }
}
