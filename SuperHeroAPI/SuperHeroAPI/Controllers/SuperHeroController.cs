using Microsoft.AspNetCore.Http;
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
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Long Island"
            }
        };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            // return Ok(heroes);
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            // var hero = heroes.Find(h => h.Id == id);
            var hero = await _context.SuperHeroes.FindAsync(id);
            
            if (hero == null)
            {
                return BadRequest("Hero is a zero!");
            }
            
            return Ok(hero);
        }

        [HttpPost]
        // public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            // heroes.Add(hero);
            // return Ok(heroes);

            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            // var hero = heroes.Find(h => h.Id == request.Id);

            //if (hero == null)
            //{
            //    return BadRequest("Hero is a zero");
            //}

            //hero.Name = request.Name;
            //hero.FirstName = request.FirstName;
            //hero.LastName = request.LastName;
            //hero.Place = request.Place;

            //return Ok(heroes);


            var dbHero = _context.SuperHeroes.Find(request.Id);

            if (dbHero == null) 
            {
                return BadRequest("Hero is a zero!");
            }

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            //var hero = heroes.Find(h => h.Id == id);

            //if (hero == null)
            //{
            //    return BadRequest("Hero is a zero!");
            //}

            //heroes.Remove(hero);

            //return Ok(heroes);

            var dbHero = await _context.SuperHeroes.FindAsync(id);

            if (dbHero == null) 
            { 
                return BadRequest("hero is a zero!"); 
            }

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
