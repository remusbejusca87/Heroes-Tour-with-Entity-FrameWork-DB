using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroesTour2;
using HeroesTour2.Data;

namespace HeroesTour2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Heroes1Controller : ControllerBase
    {
        //private static List<Hero> heroesList = new List<Hero>();

        private readonly HeroesTour2Context _context;

        public Heroes1Controller(HeroesTour2Context context)
        {
            _context = context;
        }

        // GET: search heroes
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetHero(string searchString)
        {
            //return await _context.Hero.ToListAsync();

            IQueryable<Hero> heroesFound = _context.Hero;

            if (!String.IsNullOrEmpty(searchString))
            {
                heroesFound = (IQueryable<Hero>)heroesFound.Where(a => a.firstName.ToLower().Contains(searchString) || a.lastName.ToLower().Contains(searchString));
            }
            return await heroesFound.ToListAsync();

        }


        // GET: api/Heroes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(Guid id)
        {
            var hero = await _context.Hero.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // PUT: api/Heroes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(Guid id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Heroes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            _context.Hero.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes1/5
        [HttpDelete]
        public async Task<IActionResult> DeleteHero(Guid id)
        {
            var hero = await _context.Hero.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(Guid id)
        {
            return _context.Hero.Any(e => e.Id == id);
        }



        //// GET: search heroes
        //[HttpGet]
        //public async Task<ActionResult<List<Hero>>> Search([FromQuery] Hero hero)
        //{
        //    IQueryable<Hero> heroesFound = _context.Hero;

        //    string firstNameSearched = hero.firstName.ToLower().Trim();
        //    string lastNameSearched = hero.firstName.ToLower().Trim();

        //    if (!String.IsNullOrEmpty(firstNameSearched) || !String.IsNullOrEmpty(lastNameSearched))
        //    {
        //         heroesFound = (IQueryable<Hero>)heroesFound.Where(a => a.firstName.ToLower().Contains(firstNameSearched) || a.lastName.ToLower().Contains(lastNameSearched)).ToList();
        //    }
        //    return await heroesFound.ToListAsync();
        //}



        // POST: search heroes
        //[HttpPost]
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var heroesFound = from h in _context.Hero
        //                 select h;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        heroesFound = heroesFound.Where(s => s.firstName!.ToLower().Contains(searchString));
        //    }
        //    return (IActionResult)await heroesFound.ToListAsync();
        //}

          //// GET: api/Heroes1
        //[HttpGet]
        //public async Task<IEnumerable<Hero>> GetHero()
        //{
        //    return await _context.Hero.ToListAsync();


        //}

        ////// POST: search heroes
        //[HttpPost]
        //public async Task<IEnumerable<Hero>> GetHero([FromQuery] string searchTerm, Hero hero)
        //{
        //    IQueryable<Hero> heroesFound = _context.Hero;

        //    heroesFound = heroesFound.Where(a => a.firstName.ToLower().Contains(searchTerm) || a.lastName.ToLower().Contains(searchTerm));

        //    //IQueryable<Hero> heroesFound = _context.Hero;

        //    //if (!String.IsNullOrEmpty(firstNameSearched) || !String.IsNullOrEmpty(lastNameSearched))
        //    //{
        //    //    heroesFound = (IQueryable<Hero>)heroesFound.Where(a => a.firstName.ToLower().Contains(firstNameSearched) || a.lastName.ToLower().Contains(lastNameSearched)).ToList();
        //    //}
        //    return await heroesFound.ToListAsync();

        //}



       

    }
}
