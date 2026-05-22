using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto07.SegurancaAPI
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [Authorize(Policy = "Admin")]
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok("Bem-vindo ao painel administrativo!");
        }
    }
}
