using APISample.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APISample.Config
{
    public class JWtTokenGeneration : IJWtTokenGeneration
    {
        private readonly IConfiguration _configuration;
        public JWtTokenGeneration(IConfiguration _configuration)
        {
                this._configuration = _configuration;
        }


        public string? userIsValid()
        {
            //var userDetails = SA.getUserDetails(auth);
            var userDetails = "Amit";
            if (userDetails != null)
            {
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,"APIUser"),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    //new Claim("UserName",userDetails),
                   // new Claim(ClaimTypes.Role, "Admin")

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:SecretKey"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Issuer"],
                audience: _configuration["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signIn
            );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                //return Ok(new { Token = tokenString });
                return tokenString.ToString();
            }
            // return NotFound("Invalid User Or User Not Found");
            return null;
        }
    }
}
