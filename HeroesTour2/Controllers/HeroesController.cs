using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HeroesTour2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private static List<Hero> heroesList = new List<Hero>();

        public HeroesController()
        {
            if(heroesList.Count == 0)
            {
                heroesList.Add(new Hero() { Id = Guid.NewGuid(),firstName = "Doctor", lastName = "Nice" });
                heroesList.Add(new Hero() { Id = Guid.NewGuid(),firstName = "Bombasto", lastName = "Jack" });
                heroesList.Add(new Hero() { Id = Guid.NewGuid(),firstName = "Celeritas", lastName = "Jose" });
            }
        }

        [HttpGet]
        public Hero[] Get()
        {
            return heroesList.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Hero hero)
        {
            hero.Id = Guid.NewGuid();
            heroesList.Add(hero);
        }

        [HttpDelete]

        public void Delete([FromQuery] Guid id)
        {
            Hero heroToDelete = heroesList.FirstOrDefault(x => x.Id == id);
            heroesList.Remove(heroToDelete);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public Hero Get([FromRoute] Guid id)
        {
            var hero = heroesList.FirstOrDefault(x => x.Id == id);
            if (hero != null)
            {
                return hero;
            }
            return null;
        }

        [HttpPut]
        [Route("{id:guid}")]

        public void Update([FromRoute] Guid id, [FromBody] Hero hero)
        {
            var heroToUpdate = heroesList.FirstOrDefault(x => x.Id == id);

            if(heroToUpdate != null)
            {
                heroToUpdate.firstName = hero.firstName;
                heroToUpdate.lastName = hero.lastName;

            }
        }

        


    }
}
