using Login.Entidades;
using Login.Login;
using Login.Login.Clases;
using System.Security.Cryptography;

namespace Login.Grabar
{
    public class LogicaGrabarUsuario
    {
                          //recibe un usuario de tipo auxiliar usuario y el contexto 
        public static UsuarioAuxiliar GrabarUsusuario(UsuarioAuxiliar usuario, ApplicationDbContext contexto)
        {
            //crea un nuevo usuario de tipo Usuario
           var usuarioNuevo=new Usuario();
            
            //se encripta la clave que envia del controlador en el obj usuario
            using (RSA rsa = RSA.Create())
            {
                byte[] claveUi=rsa.ExportRSAPublicKey();
                byte[] iv = rsa.ExportRSAPrivateKey();
                string claveEncriptada = EncriptarDesencriptar.Encriptar(usuario.Password, claveUi);//devuelve la clave encriptada
                usuarioNuevo.Iv = iv; // para desencriptar la clave 
                usuarioNuevo.Password = claveEncriptada;// se guarda la clave encriptada
            }
            usuarioNuevo.IdRol = usuario.IdRol;  
            usuarioNuevo.Username = usuario.Username;
            //puede llenarse los campos de la tabla restante pero
            //aqui luego delos demas campos ya no le ponemos el campo password xq ya esta encriptada
            //xq si le ponemos se crearia como una clave visualizada

            contexto.Usuarios.Add(usuarioNuevo);
            contexto.SaveChanges();
            return usuario;
        }
    }
}
