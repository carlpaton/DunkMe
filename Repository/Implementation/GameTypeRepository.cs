using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Repository.Interface;
using Repository.Schema;

namespace Repository.Implementation
{
    public class GameTypeRepository : IGameTypeRepository
    {
        public GameTypeRepository()
        {
            new DapperHelper();
        }

        public int Insert(GameTypeModel obj)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<int>(
                        "sp_insert_game_type",
                        new { obj.Name, obj.Description },
                        commandType: CommandType.StoredProcedure)
                    .Single();
            }
        }

        public List<GameTypeModel> SelectList()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStrings.Core))
            {
                return connection
                    .Query<GameTypeModel>(
                        "sp_select_list_game_type",
                        commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }
    }
}
