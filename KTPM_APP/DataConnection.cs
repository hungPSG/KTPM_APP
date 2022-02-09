using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace KTPM_APP
{
    class DataConnection
    {
        string conStr;
        public DataConnection() 
            {
                conStr = @"Data Source=DESKTOP-NDNDB0N\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True";
            }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
