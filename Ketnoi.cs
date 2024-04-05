using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
    internal class Ketnoi
    {
        SqlConnection conn;
        string conStr = @"Data Source=HUANDEPTRAI\HUAN;Initial Catalog=NguoiDung;Integrated Security=True";

        public void openKetnoi() 
        { 
             conn = new SqlConnection(conStr);
             conn.Open();
        }
               
        public SqlConnection getKetNoi()
        {
            return conn;
        }
    }
}
