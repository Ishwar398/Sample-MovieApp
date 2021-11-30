using MovieReviewApp.Models;
using MovieReviewApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Services.Implementions
{
    public class UserService : IUserService
    {
        private IDBHandler _dbService;

        public UserService(IDBHandler dbService)
        {
            _dbService = dbService;
        }

        public bool AddUser(User u)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "AddUser";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName",u.Email);
                sqlCommand.Parameters.AddWithValue("@UserEmail",u.Email);
                sqlCommand.Parameters.AddWithValue("@UserNumber",u.Number);
                sqlCommand.Parameters.AddWithValue("@BirthDate",u.BirthDate);
                sqlCommand.Parameters.AddWithValue("@Password",u.Password);

                _dbService.ExecuteQuery(sqlCommand);
                return true;

            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool SignIn(User u)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "CheckUserLogin";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName", u.Email);

                var ds = _dbService.GetQueryResults(sqlCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    var dr = ds.Tables[0].Rows[0];
                    var password = dr["Password"];

                    if (string.Equals(u.Password, password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
