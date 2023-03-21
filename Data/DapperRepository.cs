using System.Data;
using System.Data.SqlClient;

namespace Hackathon_Feature_Flagging.Data
{
    public class DapperRepository
    {
        private readonly IDbConnection _connection;

        public DapperRepository()
        {
            _connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=WeatherForecast;Integrated Security=true;");
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
