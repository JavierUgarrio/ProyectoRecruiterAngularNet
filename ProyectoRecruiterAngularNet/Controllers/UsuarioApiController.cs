using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProyectoRecruiterAngularNet.Modelos;
using ProyectoRecruiterAngularNet.Modelos.New_Models;
using ProyectoRecruiterAngularNet.Servicio;

/*
 * Utilizaremos esta api para el control de acceso de los usuarios
 * 
 * 
 * 
 */
namespace ProyectoRecruiterAngularNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private IUsuarioApi usuarioApiServicio;

        public UsuarioApiController(IConfiguration configuration, IUsuarioApi usuarioApiServicio)
        {
            this.configuration = configuration;
            this.usuarioApiServicio = usuarioApiServicio;
        }



        //utilizado de FORMA TEMPORAL PARA HACER UN ALTA
        //[HttpPost("Alta")]
        //public IActionResult AltaUsuario(AuthApiUsuario usuarioApi)
        //{
        //    Resultado res = new Resultado();
        //    try
        //    {
        //        using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
        //        {
        //            UsuarioApi apiUsu = new UsuarioApi();
        //            apiUsu.Email = usuarioApi.email;
        //            apiUsu.Password = usuarioApi.password;
        //            basedatos.UsuarioApis.Add(apiUsu);
        //            basedatos.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Error = "Se produjo un error cuando obteniendo el usuario en la Api" + ex.ToString();
        //    }
        //    return Ok(res);
        //}

        /*
         * Para recuperar el usuario
         */
        [HttpPost]
        public IActionResult dameUsuarioApi(AuthApiUsuario auth)
        {
            
            //AuthApiUsuario auth = new AuthApiUsuario();
            Resultado res = new Resultado();
            try
            {
                res.ObjetoGenerico = usuarioApiServicio.Autentication(auth);
                //using (ProyectoFpRecruiterContext basedatos= new ProyectoFpRecruiterContext())
                //{
                //    UsuarioApi usuApi = basedatos.UsuarioApis.Single(usuario=>usuario.Email == Email);
                //    auth.email = usuApi.Email;
                //    if(Pass == auth.password)
                //    {
                //        res.ObjetoGenerico = auth;
                //    }
                //    else
                //    {
                //        throw new Exception("Usuario desconocido");
                //    }
                //}
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error cuando se dio de alta el usuario en la Api" + ex.ToString();
                res.Texto = "Se produjo un error al dar del alta, por favor intentalo de nuevo";
            }
            return Ok(res);

        }
    }
}
