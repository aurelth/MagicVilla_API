using MagicVilla_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Api.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa>
            {
                new Villa{ Id=1, Name="Blumenau" },
                new Villa{ Id=2, Name="Cotonou" }
            };
        }
    }
}
