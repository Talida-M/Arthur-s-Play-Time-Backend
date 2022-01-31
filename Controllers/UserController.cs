using Microsoft.AspNetCore.Mvc;
using ProiectASP.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();

            return Ok(new { users });
        }
    }
}
