using Bookmazon.Server.Data;
using Bookmazon.Shared;
using Bookmazon.Shared.Models;
using Bookmazon.Shared.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Bookmazon.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {

        private readonly ILogger<AuthorizationController> _logger;
        private readonly DBContext _context;
        private readonly IConfiguration _configuration;

        public AuthorizationController(ILogger<AuthorizationController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("registeruser")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            var emailExists = _context.Users.Where(e => e.Email == user.Email).FirstOrDefault();
            if (emailExists == null)
            {
                var customerRole = _context.Roles.FirstOrDefault(f => f.RoleName == "customer") ??  new Roles { RoleName = "customer"};
                user.Roles = new List<Roles>();
                user.Roles.Add(customerRole);
                user.Salt = GenerateSalt();
                user.Password = PasswordHash(user.Salt, user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("authenticatetoken")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateJwt(AuthenticationRequest authenticationRequest)
        {
            string token = string.Empty;

            //checking if user exists in database
            User userExists = _context.Users.Include(i => i.Roles).Where(u =>u.Email == authenticationRequest.Email).FirstOrDefault();

            if (userExists != null)
            {
                authenticationRequest.Password = PasswordHash(userExists.Salt, authenticationRequest.Password);
                if (authenticationRequest.Password == userExists.Password)
                {
                    //generating token
                    token = GenerateJwtToken(userExists);
                }
            }
            return await Task.FromResult(new AuthenticationResponse() { Token = token });

        }



        private string GenerateSalt()
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var salt = new byte[24];
                generator.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        private string PasswordHash(string salt, string password)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 56));
            return hashedPassword;
        }

        private string GenerateJwtToken(User user)
        {
            //get secret key
            string secretKey = _configuration["JWTSettings:SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            //create claims
            Claim[] getClaims()
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserID)));
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName == null ? "" : role.RoleName.ToString()));
                }
                return claims.ToArray();
            }

            //create claimsIdentity
            var claimsIdentity = new ClaimsIdentity(getClaims(), "serverAuth");

            // generate token that is valid for 2 hours
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //creating a token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //returning the token back
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("getuserbyjwt")]
        public async Task<ActionResult<User>> GetUserByJWT([FromBody] string jwtToken)
        {
            try
            {
                //getting the secret key
                string secretKey = _configuration["JWTSettings:SecretKey"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                //preparing the validation parameters
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                //validating the token
                var principle = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = (JwtSecurityToken)securityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    //returning the user if found
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var user = await _context.Users.Include(i => i.Roles).Where(u => u.UserID == Convert.ToInt64(userId)).FirstOrDefaultAsync();
                    return user;
                }
            }
            catch (Exception ex)
            {
                //logging the error and returning null
                Console.WriteLine("Exception : " + ex.Message);
                return null;
            }
            //returning null if token is not validated
            return null;

        }
    }
}