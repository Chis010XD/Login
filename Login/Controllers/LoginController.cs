using Login.Entidades;
using Login.Login.Clases;
using Microsoft.AspNetCore.Mvc;
using ValidacionLogin;
namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]

        public ActionResult<InfoLogin> PostLogin(UsuarioUi usuario)
        {
           var respuesta = ValidarLogin.Validar(_context, usuario);

            

            return respuesta;
        }


    }
}
