using SQLite.Net;

namespace TestInTerm
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
