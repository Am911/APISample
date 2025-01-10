using APISample.Interface;
using APISample.Models;
using APISample.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserDetails IUS;
        private readonly IJWtTokenGeneration jwt;
        
        public AuthController(IConfiguration configuration, IUserDetails _IUS, IJWtTokenGeneration jwt)
        {
            this._configuration = configuration;
            this.IUS = _IUS;
            this.jwt = jwt;
            
        }

        [HttpPost]
        [Route("Token")]
        public IActionResult GetUserDetails([FromBody]  UserDetails UD)
        {
            UserDetails ud = IUS.getUserDetails(UD);
            if(ud != null)
            {
                string? jwtToken = jwt.userIsValid();
                if(jwtToken != null)
                {
                    return Ok(jwtToken);
                }
            }
            else
            {
                return Ok("Invalid UserId and Password!");
            }
            return Unauthorized();

        }

    }
}
