using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoRecruiterAngularNet.Modelos;

namespace ProyectoRecruiterAngularNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosController : ControllerBase
    {
        //Leer Proceso
        [HttpGet]
        public IActionResult dameProcesos()
        {
            Resultado res = new Resultado();
            try
            {
                using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
                {
                    var lista = basedatos.Procesos.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se obtuvo un error al extraer los procesos " + ex.Message;
            }

            return Ok(res);
        }
    }
}
