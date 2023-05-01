using System.ComponentModel.DataAnnotations;

namespace ProyectoRecruiterAngularNet.Modelos.New_Models
{
    public class AuthApiUsuario
    {
        [Required]
        public string email { get; set; }
        [Required]
        public int password { get; set; }
    }
}
