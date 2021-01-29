


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmisCamiloBautista.Dominio.Service;
using AmisCamiloBautista.Dominio.Models.Reply;
using AmisCamiloBautista.Dominio.Models.Requets;


namespace AmisCamiloBautista.Front.Controllers
{
 

    public class FormularioController : Controller
    {
        private IFormulariosService _formulario;

        public FormularioController(IFormulariosService formulario)
        {
            this._formulario = formulario;
        }

        // GET: FormularioController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        [Route("api/formulario/get")]
        public object GetFormularios()
        {
           return _formulario.GetFormularios();

        }

        [HttpGet]
        [Route("api/formulario/getid/{id}")]
        public object GetFormulariosId(int id)
        {
            return _formulario.GetFormulariosId(id);

        }

        [HttpGet("[action]")]
        [Route("api/formulario/getGeneros")]
        public object GetGeneros()
        {
            return _formulario.GetGeneros();

        }

        [HttpGet("[action]")]
        [Route("api/formulario/getCursos")]
        public object GetCursos()
        {
            return _formulario.GetCursos();

        }

        [HttpPost("[action]")]
        [Route("api/formulario/addFormulario")]
        public object AddFormulario([FromBody]EstudiantesRequest model)
        {
            return _formulario.AddFormulario(model);

        }

    }
}
