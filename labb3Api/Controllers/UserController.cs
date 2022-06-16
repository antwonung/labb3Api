
using labb3Api.Models;
using labb3Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace labb3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGenericRepository<User> _userRepository = null;


        public UserController(IGenericRepository<User> repository)
        {
            this._userRepository = repository;
        }
    
        //HÄMTA ALLA USERS
        [HttpGet("GetUsers")]
        public IActionResult GetUser()
        {
            //Hämta alla users
            var model = _userRepository.GetAll();
            return Ok(model);
        }
     
        //LÄGGA TILL EN USER
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User model)
        {
            //Adda en user
            if (ModelState.IsValid)
            {
                _userRepository.Insert(model);
                _userRepository.Save();
                return Ok();
            }
            else
                return StatusCode(500, "Something went wrong..");

        }
        
        //EDITERA EN USER
        [HttpPost("EditUser")]
        public IActionResult EditUser([FromBody] User model)
        {
            //Redigera en user
            if (ModelState.IsValid)
            {
                _userRepository.Update(model);
                _userRepository.Save();
                return Ok();
            }
            else
                return StatusCode(500, "Something went wrong..");

        }
       
    }
}
