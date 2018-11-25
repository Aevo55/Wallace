using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;

namespace Wallace.Common.Database
{
    class DatabaseWriter
    {

        private SqlCommand cmd;
        private SqlConnection conn;

        public DatabaseWriter()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=Wallace;Integrated Security=True");
        }
    }
}
