using CarMaintanance.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintanance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        IMasterRepository masterRepository1 { get; set; }
        public PruebaController(IMasterRepository masterRepository)
        {
            masterRepository1 = masterRepository;
        }

        [HttpGet]
        public IActionResult getUser(string user, string clave)
        {
            return Ok(masterRepository1.UsuarioRepository.Get(user, clave));
        }
    }
}
