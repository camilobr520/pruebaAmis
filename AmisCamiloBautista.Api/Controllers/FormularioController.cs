using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmisCamiloBautista.Dominio.Service;
using AmisCamiloBautista.Dominio.Models.Reply;
using AmisCamiloBautista.Dominio.Models.Requets;

namespace AmisCamiloBautista.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : ControllerBase
    {
        private IFormulariosService _formulario;

        public FormularioController(IFormulariosService formulario)
        {
            this._formulario = formulario;
        }

        //listar formularios
        [HttpGet]
        [Route("api/formularios")]
        public IActionResult GetFormularios()
        {
            return Ok(_formulario.GetFormularios()) ;
        }

        //consulta de formulario por id
        [HttpGet]
        [Route("api/formulariosid")]
        public IActionResult GetFormulariosId(int id)
        {
            return Ok(_formulario.GetFormulariosId(id));
        }

        //creación de formulario
        [HttpPost]
        [Route("api/addformulario")]
        public IActionResult AddFormularios([FromBody] EstudiantesRequest model)
        {
            return Ok(_formulario.AddFormulario(model));
        }
    }
}
