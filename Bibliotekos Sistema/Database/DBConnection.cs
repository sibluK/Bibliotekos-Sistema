using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bibliotekos_Sistema.Database
{
    class DBConnection
    {
        //desktop - desktop-65cg94l
        //laptop - desktop-c10r285
        private SqlConnection _connection = new SqlConnection("Data source=desktop-65cg94l; Initial catalog=Bibliotekos_Sistema; Integrated security=true;");

        public SqlConnection connection()
        {
            return _connection;
        }

    }
}

