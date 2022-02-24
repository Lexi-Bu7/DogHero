using DogHeroApi.Module;
using DogHeroApi.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DataContext _context;

        public DogController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Dog>>> GetDogs()
        {
            return await _context.Dogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
           
            return await _context.Dogs.FindAsync(id);   
        }

        [HttpPost]
        public async Task<ActionResult<Dog>> AddDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();  
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Dog>> EditeDogs(int id, Dog dogDTO)
        {

            if(id != dogDTO.Id)
            {
                return BadRequest("can't find the dog matches id");
            }

            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            
            dog.Name = dogDTO.Name; 
            dog.Age = dogDTO.Age;   
            dog.Breeder = dogDTO.Breeder;   

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Dog>> DeleteDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);  
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }
}
