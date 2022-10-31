using System.Data.SqlClient;

namespace CheckoutApp_CL.DAL
{
    public abstract class CommonDAL
    {
        const string connString = "Data Source=.;Initial Catalog=CheckoutDB;Integrated Security=SSPI;Pooling=False";
        protected SqlConnection conn;

        protected CommonDAL()
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }
    }
}
