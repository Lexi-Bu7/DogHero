using DogHeroApi.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        public static List<Dog> Dogs()
        {

            var dogs = new List<Dog>
            {
                new Dog
                {
                Id = 1, Name = "Fawn", Age = 4, Gender =Gender.Female, Weight = 21.98, Breeder = "Welsh Corgi"
                },
                new Dog
                {
                Id = 2, Name = "Buck", Age = 23, Gender =Gender.Male, Weight = 200, Breeder = "American Deer"
                }
            };
            return dogs;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dog>>> GetDogs()
        {
            return Ok(Dogs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dog>>> GetDog(int id)
        {
            var dog = Dogs().Find(x => x.Id == id);

            if (dog == null)
            {
                return BadRequest(dog);
            }
            return Ok(dog);
        }

        [HttpPost]
        public async Task<ActionResult<Dog>> AddDog(Dog dog)
        {
            var dogs = Dogs();
            dogs.Add(dog);
            return Ok(dogs);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Dog>>> EditeDogs(int id, Dog dogDTO)
        {

            if(id != dogDTO.Id)
            {
                return BadRequest("can't find the dog matches id");
            }
            
            var dogs = Dogs();
            var dog = dogs.Find(x => x.Id == id);

            if (dog == null)
            {
                return NotFound();
            } 
            dog.Name = dogDTO.Name; 
            dog.Age= dogDTO.Age;    
            return Ok(dogs);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Dog>>> DeleteDog(int id)
        {
            var dogs = Dogs();
            var dog = dogs.Find(x => x.Id == id);

            if (dog == null)
            {
                return NotFound("Hero not Found");
            }
            dogs.Remove(dog);
            return Ok(dogs);
        }

    }
}
