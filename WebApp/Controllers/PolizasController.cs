using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PolizasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IJwtAuthManager _jwtAuthManager;
        public PolizasController(DataContext context, IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Poliza> Get()
        {
            var todos = _context.Polizas.ToList();
            return todos;
         
        }


        [HttpPost]
        public  bool VentaPoliza(PolizaVenta poliza )
        {
            bool respuesta = false;
            try
            {
                if (poliza.Fecha_Fin != poliza.Fecha_vencimiento_poliza_actual)
                {
                    respuesta = false;
                }
                else
                {

                    var ciudades = _context.Ciudades.Where(r => r.Permitida == true).ToList();
                    var ciudad = ciudades.Where(r => r.Id == poliza.IdCiudad).FirstOrDefault();
                    if ( ciudad != null   && ciudad.Id>0)
                    {
                        Poliza polizaG = new Poliza
                        {
                            Datos_tomador = poliza.Datos_tomador,
                            Placa_Automotor = poliza.Placa_Automotor,
                            Fecha_Fin = poliza.Fecha_Fin,
                            Fecha_inicio = poliza.Fecha_inicio,
                            Fecha_vencimiento_poliza_actual = poliza.Fecha_vencimiento_poliza_actual, ciudad = ciudad
                        };
                        _context.Polizas.Add(polizaG);
                        _context.SaveChanges();
                        
                        respuesta = true;
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        private bool PolizaExists(int id)
        {
            return _context.Polizas.Any(e => e.Id == id);
        }
    }

    public class LoginResult
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("emailUser")]
        public string EmailUser { get; set; }

        [JsonPropertyName("razonSocial")]
        public string RazonSocial { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
