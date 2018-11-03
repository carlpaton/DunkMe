using Dapper;

namespace Repository
{
    //TODO - this along with the 'new SqlConnection()' can be moved into a factory

    public class DapperHelper
    {
        public DapperHelper()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
