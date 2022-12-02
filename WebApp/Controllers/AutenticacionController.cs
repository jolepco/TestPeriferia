using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IConfiguration _configuracion;

        public AutenticacionController( IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> valortoken()
        {
            
            string secreto = _configuracion.GetValue<string>("secret").ToString();
            string usuario = _configuracion.GetValue<string>("usertest").ToString();
           // string user = ConfigurationManager.AppSettings["usertest"].ToString();
           // string clave = ConfigurationManager.AppSettings["clavetest"].ToString();


            string secreto2 = _configuracion.GetValue<string>("secret");
            var key = Encoding.ASCII.GetBytes(secreto);




            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenhandler = new JwtSecurityTokenHandler();
            var createtoken = tokenhandler.CreateToken(tokenDescriptor);
            string bearer_token = tokenhandler.WriteToken(createtoken);

            await Task.Delay(1);
            return Ok(bearer_token);

        }

    }
}
