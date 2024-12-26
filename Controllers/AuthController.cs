using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteHG.Models;
using RestauranteHG.Security;
using System.Text;

namespace RestauranteHG.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly AppDbContext _context; 
            private readonly JwtService _jwtService;

            public AuthController(AppDbContext context, JwtService jwtService)
            {
                _context = context;
                _jwtService = jwtService;
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginRequest request)
            {
                var user = await _context.Usuarios
                    .Include(u => u.Rol)
                    .ThenInclude(r => r.RolPermisos)
                    .ThenInclude(rp => rp.Permiso)
                    .FirstOrDefaultAsync(u => u.Usuario1 == request.usuario);

                if (user == null || !VerifyPassword(request.contrasena, user.ContrasenaHash))
                {
                    return Unauthorized("Credenciales incorrectas.");
                }

                var roles = new List<string> { user.Rol.Nombre };

                var token = _jwtService.GenerateToken(user.UsuarioId, user.Usuario1, roles);

                return Ok(new { Token = token });
            }

            private bool VerifyPassword(string password, byte[] storedHash)
            {
                using var sha256 = System.Security.Cryptography.SHA256.Create();
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }
        public class LoginRequest
        {
            public string? usuario { get; set; }
            public string? contrasena { get; set; }
        }

    
}
