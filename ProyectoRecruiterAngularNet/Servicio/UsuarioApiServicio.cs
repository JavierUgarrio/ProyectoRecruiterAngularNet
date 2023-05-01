using ProyectoRecruiterAngularNet.Modelos;
using ProyectoRecruiterAngularNet.Modelos.New_Models;

namespace ProyectoRecruiterAngularNet.Servicio
{
    public class UsuarioApiServicio : IUsuarioApi
    {
        private readonly IConfiguration configuration;

        public UsuarioApiServicio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public UsuarioApiViewModel Autentication(AuthApiUsuario AuthApi)
        {
            UsuarioApiViewModel res = new UsuarioApiViewModel();
            using (ProyectoFpRecruiterContext basedatos = new ProyectoFpRecruiterContext())
            {
                UsuarioApi usuarioApi = basedatos.UsuarioApis.Single(usuario => usuario.Email == AuthApi.email);
                if(usuarioApi!=null & AuthApi.password == usuarioApi.Password)
                {
                    res.email = usuarioApi.Email;

                }
                else
                {
                    throw new Exception("Usuario desconocido");
                }
            }
            return res;
        }
    }
}
