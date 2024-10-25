using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;




namespace StorEasyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthUserController : ControllerBase
    {
        private readonly IAuthUserRepository _authUserRepository;

        public AuthUserController(IAuthUserRepository authUserRepository)
        {
            _authUserRepository = authUserRepository;
        }

        [Authorize]
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _authUserRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound(); // Retorna 404 se o usuário não for encontrado
            }

            return Ok(user); // Retorna 200 com os dados do usuário
        }

        // Endpoint para validar um usuário
        [HttpPost("validate")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUserRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var token = await _authUserRepository.ValidateUserAsync(request.Username, request.Password);
            if (token == null)
            {
                return Unauthorized(); // Retorna 401 se a validação falhar
            }

            return Ok(new { Token = token }); // Retorna 200 se o usuário for validado
        }
    }

    // Classe de solicitação para validação de usuário
    public class ValidateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
