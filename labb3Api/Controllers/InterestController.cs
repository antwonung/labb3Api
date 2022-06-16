using labb3Api.Models;
using labb3Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace labb3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IGenericRepository<UserInterest> _userInterest = null;
        private IGenericRepository<Interest> _Interest = null;


        public InterestController(IGenericRepository<UserInterest> UserInterestRep,IGenericRepository<Interest> interestRep)
        {
            this._userInterest = UserInterestRep;
            this._Interest = interestRep;    
        }

        //HÄMTA ALLA INTRESSEN
        [HttpGet("GetInterests")]
        public IActionResult GetInterests()
        {
           
            var model = _Interest.GetAll();
            return Ok(model);
        }

        //LÄGG TILL ETT INTRESSE
        [HttpPost("AddInterest")]
        public IActionResult AddInterest([FromBody] Interest model)
        {
            
            if (ModelState.IsValid)
            {
                _Interest.Insert(model);
                _Interest.Save();
                return Ok();
            }
            else
                return StatusCode(500, "Something went wrong..");

        }

        //HÄMTA EN PERSONS INTRESSEN
        [HttpGet("GetUsersInterest/{id}")]
        public IActionResult GetUserInterest([FromRoute] int id)
        {
            var result = _userInterest.Query.Where(u => u.UserId == id).Include(i => i.Interest).ToList();
            return Ok(result);
            

        }
        
        //KOPPLA EN PERSON TILL ETT NYTT INTRESSE
        [HttpPost("SetNewUserInterest")]
        public IActionResult GetUserInterest([FromBody] UserInterest obj )
        {
            _userInterest.Insert(obj);
            _userInterest.Save();
            return Ok();


        }

    }
}
