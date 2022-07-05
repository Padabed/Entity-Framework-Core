using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeFirst.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirst.Controllers
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("api/clients/{IdClient}")]
        public async Task<IActionResult> GetAllClientOrders(int IdClient)
        {
            try
            {
                var result = await _clientService.GetAllClientOrdersAsync(IdClient);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    
    }
}

