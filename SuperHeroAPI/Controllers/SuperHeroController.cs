using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    { 

        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name = "Énio",
                    FirstName = "Énio",
                    LastName = "Carlos",
                    Place = "Luanda, Angola"
                },
                new SuperHero {
                    Id = 2,
                    Name = "Goddamn",
                    FirstName = "Miguel",
                    LastName = "Paulo",
                    Place = "Bié, Angola"
                }
            };
    
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var superHero = heroes.Find(h => h.Id == hero.Id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            superHero.Name = hero.Name;
            superHero.FirstName = hero.FirstName;
            superHero.LastName = hero.LastName;
            superHero.Place =  hero.Place;

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            heroes.Remove(hero);
            return Ok(hero);
        }
    }
}
