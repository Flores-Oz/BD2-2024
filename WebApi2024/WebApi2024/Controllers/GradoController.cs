using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi2024.Data;
using WebApi2024.Models;

namespace WebApi2024.Controllers
{
    [Route("grado")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public List<GradoModel> listadoGrados()
        {
            return DataCliente.ListadoGrados();
        }

        [HttpPost]
        [Route("ingresoGrado")]
        public int NuevoGrado(GradoModel nuevaGrado)
        {
            return DataCliente.NuevoGrado(nuevaGrado);
        }
    }
}
