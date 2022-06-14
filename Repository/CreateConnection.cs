using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDVideoGamesApp.Repository
{
    public static class CreateConnection
    {
        public static SqlConnection CreateCnn(string name)
        {
            return new SqlConnection(name);
        }
    }
}
