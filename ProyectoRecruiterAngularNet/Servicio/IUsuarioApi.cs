using ProyectoRecruiterAngularNet.Modelos.New_Models;

namespace ProyectoRecruiterAngularNet.Servicio
{
    public interface IUsuarioApi
    {
        public UsuarioApiViewModel Autentication(AuthApiUsuario AuthApi);
    }
}
