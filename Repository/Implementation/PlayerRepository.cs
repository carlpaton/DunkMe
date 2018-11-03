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
            throw new System.NotImplementedException();
        }

        public List<PlayerModel> SelectList()
        {
            throw new System.NotImplementedException();
        }
    }
}
