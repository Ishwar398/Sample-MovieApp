using MovieReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Services.Interfaces
{
    public interface IUserService
    {
        public bool AddUser(User u);
        public bool SignIn(User u);
    }
}
