using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System.Data.SQLite;
using System.Windows;
namespace Warung
{
    class koneksi
    {
       public SQLiteConnection cn;
       public koneksi()
        {
            IntCon();
        }
        public void IntCon()
        {
            
            cn = new SQLiteConnection("Data Source = warung.db3; Version = 3; New = False; Compress = True;");
            cn.Open();
        }
       
        
        
    }
}
