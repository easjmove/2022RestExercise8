using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestExercise8.Managers;
using RestExercise8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExercise8.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private IFlowersManager _manager;

        public FlowersController(RestContext _context)
        {
            //if (you want db)
            _manager = new FlowersManagerDB(_context);
            //else
            //_manager = new FlowersManagerList();
        }

        // GET: api/<FlowersController>
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Flower>> Get(
            [FromQuery] string? speciesFilter,
            [FromQuery] string? colorFilter)
        {
            IEnumerable<Flower> list = _manager.GetAll(speciesFilter, colorFilter);
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        // GET api/<FlowersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Flower> Get(int id)
        {
            Flower? foundFlower = _manager.GetById(id);
            if (foundFlower == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundFlower);
            }
        }

        // POST api/<FlowersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Flower> Post([FromBody] Flower newFlower)
        {
            try
            {
                Flower createdFlower = _manager.Add(newFlower);
                return Created("/" + createdFlower.Id, createdFlower);
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

        // PUT api/<FlowersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Flower> Put(int id, [FromBody] Flower updates)
        {
            try
            {
                Flower? updatedFlower = _manager.Update(id, updates);
                if (updatedFlower == null)
                {
                    return NotFound();
                }
                return Ok(updatedFlower);
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

        // DELETE api/<FlowersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Flower> Delete(int id)
        {
            Flower? deletedFlower = _manager.Delete(id);
            if (deletedFlower == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deletedFlower);
            }
        }
    }
}
