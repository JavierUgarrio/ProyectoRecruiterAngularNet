using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoRecruiterAngularNet.Modelos;
using ProyectoRecruiterAngularNet.Modelos.New_Models;

namespace ProyectoRecruiterAngularNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //Modificar Usuario

        [HttpPut]
        public IActionResult ModificarUsuario(UsuariosViewModel u)
        {
            Resultado res = new Resultado();
            try
            {
                using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
                {
                    Usuario usuario = basedatos.Usuarios.Single(usu => usu.Email == u.Email);
                    usuario.Nombre = u.Nombre;
                    usuario.Apellidos = u.Apellidos;
                    usuario.Password = u.Password;
                    basedatos.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                    basedatos.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                res.Error = "Se obtuvo un error al editar un usuario " + ex.Message;
            }

            return Ok(res);
        }

        //Leer Usuario
        [HttpGet]
        public IActionResult extraerDatos()
        {
            Resultado res = new Resultado();
            try
            {
                using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
                {
                    var lista = basedatos.Usuarios.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se obtuvo un error al extraer los usuarios "+ ex.Message;
            }

            return Ok(res);
        }
        //Añadir Usuario
        
        [HttpPost]
        public IActionResult agregarUsuario(UsuariosViewModel u)
        {
            Resultado res = new Resultado();
            try
            {
                using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
                {
                    Usuario usuario = new Usuario();
                    usuario.Nombre = u.Nombre;
                    usuario.Apellidos = u.Apellidos;
                    usuario.Telefono = u.Telefono;
                    usuario.Email = u.Email;
                    usuario.Password = u.Password;
                    usuario.FechaAlta = DateTime.Now;
                    basedatos.Usuarios.Add(usuario);
                    basedatos.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                res.Error = "Se obtuvo un error al realizar el alta " + ex.Message;
            }

            return Ok(res);
        }

        //Eliminar Registro Usuario

        [HttpDelete("{Email}")]
        public IActionResult EliminarUsuario(String Email)
        {
            Resultado res = new Resultado();
            try
            {
                using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
                {
                    Usuario usuario = basedatos.Usuarios.Single(usu => usu.Email == Email);
                    basedatos.Remove(usuario);
                    basedatos.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    basedatos.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                res.Error = "Se obtuvo un error al eliminar un usuario " + ex.Message;
            }

            return Ok(res);
        }



    }
}
