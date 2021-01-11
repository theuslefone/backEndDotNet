using curso.api.Filters;
using curso.api.Models;
using curso.api.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private object usuarioViewModelOutput;

        /// <summary>
        /// teste
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description:"Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatorios", Type = typeof(ValidaCampoViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewmodel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizada]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ValidaCampoViewModelInput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //}
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "theuslefone",
                Email = "matheuskeeven22@gmail.com"
            };



            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jh\\2.}8ZP'qY#7");
            var symetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandeler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandeler.CreateToken(securityTokenDescriptior);
            var token = jwtSecurityTokenHandeler.WriteToken(tokenGenerated);

            return Ok(new 
            {
                   Token = token,
                   Usuario = usuarioViewModelOutput

            });
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        } 
    }
}
