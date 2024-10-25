using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



public interface IAuthUserRepository
{
    Task<AuthUser> GetUserByUsernameAsync(string username);
    Task<string> ValidateUserAsync(string username, string password);
}
