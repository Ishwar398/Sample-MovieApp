using Microsoft.Extensions.Configuration;
using MovieReviewApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Services.Implementions
{
    public class DBHandler: IDBHandler
    {
        private IConfiguration _configuration;
        private SqlConnection _sqlConnection;

        public DBHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:MainDB"));
        }

        public bool ExecuteQuery(SqlCommand sqlCommand)
        {
            bool _didExecute = false;
            _sqlConnection.Open();
            try
            {
                sqlCommand.Connection = _sqlConnection;
                sqlCommand.ExecuteNonQuery();
                _didExecute = true;
            }
            catch (SqlException sqlE)
            {
                _didExecute = false;
                _sqlConnection.Close();
            }
            catch (Exception e)
            {
                _didExecute = false;
                _sqlConnection.Close();
            }
            return _didExecute;

        }

        public DataSet GetQueryResults(SqlCommand sqlCommand)
        {
            bool _didExecute = false;
            try
            {
                sqlCommand.Connection = _sqlConnection;
                DataSet ds = new DataSet();
                var sqlAdapter = new SqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(ds);
                return ds;
            }
            catch (SqlException sqlE)
            {
                _didExecute = false;
                throw sqlE;
            }
            catch (Exception e)
            {
                _didExecute = false;
                throw e;
            }

        }
    }
}
