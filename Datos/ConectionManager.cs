using System.Data.SqlClient;
namespace Datos
{
    public class ConectionManager
    {
        public readonly SqlConnection _connection;

        public ConectionManager(string connection)
        {
            _connection = new SqlConnection(connection);
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}