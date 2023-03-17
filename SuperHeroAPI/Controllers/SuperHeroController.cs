﻿using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    { 

        private readonly DataContext context;

        public SuperHeroController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            
            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();

            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var dbHero = await context.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
            {
                return BadRequest("Hero Not Found");
            }
            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place =  request.Place;

            await context.SaveChangesAsync();

            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("Hero Not Found");
            }

            context.SuperHeroes.Remove(dbHero);
            _ = context.SaveChangesAsync();

            return Ok(await context.SuperHeroes.ToListAsync());
        }
    }
}
