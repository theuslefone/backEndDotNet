using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Este seviço permite cadastrar curso para o usuário autenticado.
        /// </summary>
        /// <param name="cursoViewModelInput"></param>
        /// <returns>Retorna criado</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar o curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]

        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário
        /// </summary>
        /// <returns>Retorna status OK e dados dos curoso do usuario</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter os cursos")]
        [SwaggerResponse(statusCode: 400, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {

            var cursos = new List<CursoViewModelOutput>();
            var CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            cursos.Add(new CursoViewModelOutput() 
            {
                Login = "Teste",
                Descricao  = "teste",
                Nome = "teste"
            });
            return Ok(cursos);
        }

    }
}
