using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestExercise8.Managers;
using RestExercise8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExercise8.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class IPAsController : ControllerBase
    {
        private IIPAsManager _manager;

        public IPAsController(RestContext _context)
        {
            //if (you want db)
            _manager = new IPAsManagerDB(_context);
            //else
            //_manager = new IPAsManagerList();
        }

        // GET: api/<IPAsController>
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<IPA>> Get(
            [FromQuery] double? minimumProof,
            [FromQuery] double? maximumProof,
            [FromQuery] string? nameFilter)
        {
            IEnumerable<IPA> list = _manager.GetAll(minimumProof, maximumProof, nameFilter);
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        // GET api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<IPA> Get(int id)
        {
            IPA foundIPA = _manager.GetById(id);
            if (foundIPA == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundIPA);
            }
        }

        // POST api/<IPAsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<IPA> Post([FromBody] IPA newIPA)
        {
            try
            {
                IPA createdIPA = _manager.Add(newIPA);
                return Created("/" + createdIPA.Id, createdIPA);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<IPA> Put(int id, [FromBody] IPA updates)
        {
            try
            {
                IPA updatedIPA = _manager.Update(id, updates);
                if (updatedIPA == null)
                {
                    return NotFound();
                }
                return Ok(updatedIPA);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<IPA> Delete(int id)
        {
            IPA deletedIPA = _manager.Delete(id);
            if (deletedIPA == null)
            {
                return NotFound();
            } else
            {
                return Ok(deletedIPA);
            }
        }
    }
}
