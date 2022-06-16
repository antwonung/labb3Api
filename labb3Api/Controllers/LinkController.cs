using labb3Api.Models;
using labb3Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace labb3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private IGenericRepository<UserInterest> _UserInterest = null;
        private IGenericRepository<Links> _Links = null;

        public LinkController(IGenericRepository<UserInterest> userInterestRepo,IGenericRepository<Links> linkRepo)
        {
            this._UserInterest = userInterestRepo;
            this._Links = linkRepo;
        }

        //HÄMTA EN PERSONS INTRESSE LÄNKAR
        [HttpGet("GetUsersLinks/{id}")]
        public IActionResult GetUsersLinks([FromRoute] int id)
        {
            var result = _UserInterest.Query.Where(u => u.UserId == id).Include(i => i.Interest)
                .ThenInclude(l => l.Links).Select(s => s.Interest.Links).ToList();
            return Ok(result);
        
        }

        //ADDA EN NY LÄNK TILL ETT INTRESSE
        [HttpPost("NewLinkToInterest")]
        public IActionResult NewLinkToInterest([FromBody] Links obj)
        {
            _Links.Insert(obj);
            _Links.Save();
            return Ok();


        }
    }
}
