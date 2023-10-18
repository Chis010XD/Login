
using Login.Entidades;
using Login.Login;
using Login.Login.Clases;

namespace ValidacionLogin { 

    public class ValidarLogin
    {
        public static InfoLogin Validar(ApplicationDbContext contexto,UsuarioUi usuario)
        {
            var usuarioConsulta = contexto.Usuarios.Where(resp => resp.Username == usuario.NombreUsuario).FirstOrDefault();

            var resp = new InfoLogin();

             if (usuarioConsulta==null)
            {
                resp.info = "No se encontro";
            }
            else 
            {
                //valida la clave
                string claveDesencriptada = EncriptarDesencriptar.Desencriptar(usuarioConsulta.Password, usuarioConsulta.Iv);

                if (claveDesencriptada==usuario.Clave)
                {
                    resp.info = "valido";
                }
                else
                {
                    resp.info = "No es la clave";
                }
            }
            return resp;       
        }
    }
}

