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
                user.Salt = GenerateSalt();
                user.Password = PasswordHash(user.Salt, user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost("loginuser")]
        public async Task<ActionResult> LoginUser(User user)
        {
            var userExists = _context.Users.Where(u =>u.Email == user.Email).FirstOrDefault();
            if (userExists != null)
            {
                var password = PasswordHash(userExists.Salt, user.Password);

                if (password == userExists.Password)
                {
                    //create a claim
                    var claimEmail = new Claim(ClaimTypes.Email, userExists.Email);
                    var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, userExists.UserID.ToString());
                    //create claimsIdentity
                    var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, claimNameIdentifier }, "serverAuth");
                    //create claimsPrincipal
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    //Sign In User
                    await HttpContext.SignInAsync(claimsPrincipal);
                }
            }

            return Ok();
        }

        [HttpPost("authenticatetoken")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateJwt(AuthenticationRequest authenticationRequest)
        {
            string token = string.Empty;

            User userExists = _context.Users.Where(u =>u.Email == authenticationRequest.Email).FirstOrDefault();

            if (userExists != null)
            {
                authenticationRequest.Password = PasswordHash(userExists.Salt, authenticationRequest.Password);
                if (authenticationRequest.Password == userExists.Password)
                {
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
            string secretKey = _configuration["JWTSettings:SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claimEmail = new Claim(ClaimTypes.Email, user.Email);
            var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString());

            var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, claimNameIdentifier }, "serverAuth");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

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
                    return await _context.Users.FirstOrDefaultAsync(u => u.UserID == Convert.ToInt64(userId));
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