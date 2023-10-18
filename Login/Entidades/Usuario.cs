using System;
using System.Collections.Generic;

namespace Login.Entidades
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[] Iv { get; set; } = null!;
      
    }
}
