using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Services.Interfaces
{
    public interface IDBHandler
    {
        public DataSet GetQueryResults(SqlCommand sqlCommand);

        public bool ExecuteQuery(SqlCommand sqlCommand);
    }
}
