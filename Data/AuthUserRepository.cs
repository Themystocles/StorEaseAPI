using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AuthUserRepository : IAuthUserRepository
{
    private readonly ConnectionContext _context;
    private readonly JwtService _jwtService;

    public AuthUserRepository(ConnectionContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<AuthUser> GetUserByUsernameAsync(string username)
    {
        return await _context.AuthUser
            .FirstOrDefaultAsync(user => user.UserName == username);
    }

    public async Task<string> ValidateUserAsync(string username, string password)
    {
        var user = await GetUserByUsernameAsync(username);
        if (user == null || user.PasswordHash != password)
        {
            return null; // Retorna null se a autenticação falhar
        }

        return _jwtService.GenerateToken(user);
    }

}
