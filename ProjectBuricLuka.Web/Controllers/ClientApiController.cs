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
    [Route("api/client")]
    [ApiController]
    public class ClientApiController : Controller
    {
        private VideoGamesDbContext _dbContext;

        public ClientApiController(VideoGamesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /*
        public IActionResult Get()
        {
            var cities = this._dbContext.Cities.Select(c=> new CityDTO() { ID=c.ID,Name=c.Name}).ToList();   
            var clients = this._dbContext.Clients.Select(c=>new ClientDTO()
            {   ID=c.ID,
                FullName=c.FullName,
                Address=c.Address,
                Email=c.Email,
                City=new CityDTO() { ID=c.City.ID,Name=c.City.Name}
            }).ToList();

            return Ok(clients);
        }


        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var cities = this._dbContext.Cities.Select(c => new CityDTO() { ID = c.ID, Name = c.Name }).ToList();
            var clients = this._dbContext.Clients.Where(c=>c.ID==id).Select(c => new ClientDTO()
            {
                ID = c.ID,
                FullName = c.FullName,
                Address = c.Address,
                Email = c.Email,
                City = new CityDTO() { ID = c.City.ID, Name = c.City.Name }
            }).FirstOrDefault();

            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [Route("pretraga/{q}")]
        public IActionResult Get(string q)
        {
            var cities = this._dbContext.Cities.Select(c => new CityDTO() { ID = c.ID, Name = c.Name }).ToList();
            List<ClientDTO> clients = NewMethod();

            clients = clients.Where(c => c.FullName.ToLower().Contains(q.ToLower())).ToList();

            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Client client)
        {           
            this._dbContext.Clients.Add(new Client()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Gender = client.Gender,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                WorkingExperience = client.WorkingExperience,
                DateOfBirth = client.DateOfBirth,
                CityID = client.CityID        
            });

            this._dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]Client client)
        {
            var cl = this._dbContext.Clients.First(c=>c.ID == id);
            cl.FirstName = client.FirstName;
            cl.LastName = client.LastName;
            cl.Email = client.Email;
            cl.Gender = client.Gender;
            cl.Address = client.Address;
            cl.PhoneNumber = client.PhoneNumber;
            cl.WorkingExperience = client.WorkingExperience;
            cl.DateOfBirth = client.DateOfBirth;
            cl.CityID = client.CityID;

            this._dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var client = this._dbContext.Clients.FirstOrDefault(c=>c.ID==id);
            this._dbContext.Remove(client);
            this._dbContext.SaveChanges();
            return Ok();
        }
      

        private List<ClientDTO> NewMethod()
        {
            return this._dbContext.Clients.Select(c => new ClientDTO()
            {
                ID = c.ID,
                FullName = c.FullName,
                Address = c.Address,
                Email = c.Email,
                City = new CityDTO() { ID = c.City.ID, Name = c.City.Name }
            }).ToList();
        }
        */
    }
}
