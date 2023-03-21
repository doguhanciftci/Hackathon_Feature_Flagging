using Dapper;
using Hackathon_Feature_Flagging.Models;

namespace Hackathon_Feature_Flagging.Data
{
    public class FlagRepository
    {
        private const string SelectQuery = "SELECT ID, DESCRIPTION, VALUE FROM FLAGS WHERE ID = @Id";
        private readonly DapperRepository _dapperRepository;

        public FlagRepository(DapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public Flag GetFlag(int id)
        {
            Flag result = _dapperRepository
                            .Connection
                            .Query<Flag>(SelectQuery, new { Id = id })
                            .First();

            return result;
        }

    }
}
