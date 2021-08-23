using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDB
{
    public class DBContext
    {
        public IDbConnection db;

        public DBContext(string Connectionstring)
        {
            IDbConnection _db = new SqlConnection(Connectionstring);

            db = _db;
        }


    }
}
