using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi2024.Models;
using WebApi2024.Data;

namespace WebApi2024.Controllers
{
    [Route("carrera")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public List<CarreraModel> listadoCarreras()
        {
            return DataCliente.ListadoCarrera();
        }

        [HttpPost]
        [Route("ingresoCarrera")]
        public int NuevaCarrera(CarreraModel nuevaCarrera)
        {
            return DataCliente.NuevaCarrera(nuevaCarrera);
        }
        [HttpDelete]
        [Route("eliminarCarrera/{id}")]
        public int EliminarCarrera(string id)
        {
            return DataCliente.EliminarCarrera(id);
        }
    }
}
