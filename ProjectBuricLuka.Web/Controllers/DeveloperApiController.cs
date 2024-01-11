using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBuricLuka.DAL;
using ProjectBuricLuka.Model;
using ProjectBuricLuka.Web.Models;

namespace Vjezba.Web.Controllers
{
    [Route("api/developer")]
    [ApiController]
    public class DeveloperApiController : Controller
    {
        private VideoGamesDbContext _dbContext;

        public DeveloperApiController(VideoGamesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        
        public IActionResult Get()
        {
              
            
            var developers = this._dbContext.Developers.Select(d => new DeveloperDTO()
            {   ID=d.ID,
                Name=d.Name,
                Website=d.Website,
                YearFounded=d.YearFounded,
                CityProjectDTO=new CityProjectDTO() { ID= (int)d.CityProjectID,Name=d.CityProject.Name}
            
            
            }).ToList();
         
            return Ok(developers);
        }
        
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var developers = this._dbContext.Developers.Where(d => d.ID == id).Select(d => new DeveloperDTO()
            {
                ID = d.ID,
                Name = d.Name,
                Website = d.Website,
                YearFounded = d.YearFounded,
                CityProjectDTO = new CityProjectDTO() { ID = (int)d.CityProjectID, Name = d.CityProject.Name }


            }).FirstOrDefault();

            if (developers == null)
            {
                return NotFound();
            }
            return Ok(developers);
        }
        


        
        [Route("pretraga/{q}")]
        public IActionResult Get(string q)
        {
            //var cities = this._dbContext.Cities.Select(c => new CityDTO() { ID = c.ID, Name = c.Name }).ToList();
            var developers = this._dbContext.Developers.Select(d => new DeveloperDTO()
            {
                ID = d.ID,
                Name = d.Name,
                Website = d.Website,
                YearFounded = d.YearFounded,
                CityProjectDTO = new CityProjectDTO() { ID = (int)d.CityProjectID, Name = d.CityProject.Name }


            }).ToList();

            developers = developers.Where(c => c.Name.ToLower().Contains(q.ToLower())).ToList();

            if (developers == null)
            {
                return NotFound();
            }
            return Ok(developers);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Developer developer)
        {           
            this._dbContext.Developers.Add(new Developer()
            {
                Name = developer.Name,
                Website = developer.Website,
                YearFounded = developer.YearFounded,           
                CityProjectID = developer.CityProjectID        
            });

            this._dbContext.SaveChanges();

            return Ok();
        }
        

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]Developer developer)
        {
            var dev = this._dbContext.Developers.First(d => d.ID == id);
            dev.Name=developer.Name;
            dev.Website=developer.Website;
            dev.YearFounded=developer.YearFounded;
            dev.CityProjectID=developer.CityProjectID;

            this._dbContext.SaveChanges();

            return Ok();
        }
        

        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var dev=this._dbContext.Developers.FirstOrDefault(d=>d.ID==id);   
            this._dbContext.Remove(dev);
            this._dbContext.SaveChanges();
            return Ok();
        }
      
        
    }
}
