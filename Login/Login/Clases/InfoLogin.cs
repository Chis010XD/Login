namespace Login.Login.Clases
{
    public class InfoLogin
    {
        public string info { get; set; }

    }
    public class UsuarioUi
    {
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;
    }

    public class UsuarioAuxiliar
    {
       
        public int IdRol { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        
    }
}
    