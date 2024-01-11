using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class DeveloperController : BazniController
    {
        
        public DeveloperController(VideoGamesDbContext dbContext, UserManager<AppUser> userManager) : base(dbContext, userManager)
        {
        }

     
        [AllowAnonymous]
        public ActionResult Index(DeveloperFilterModel filter)
        {
            filter ??= new DeveloperFilterModel();

            var developerQuery = this._dbContext.Developers.Include(c=>c.CityProject).AsQueryable();

           
            if (!string.IsNullOrWhiteSpace(filter.Name))
                developerQuery = developerQuery.Where(g => (g.Name).ToLower().Contains(filter.Name.ToLower()));
        
            var model = developerQuery.ToList();
            return View("Index", model);
        }

        [AllowAnonymous]
        public IActionResult Details(int? id = null)
        {
            var dev = this._dbContext.Developers
                .Include(c => c.CityProject)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(dev);
        }


        [Authorize]
        public IActionResult Create()
        {
            this.FillDropdownValuesCity();
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(Developer model)
        {
            if (ModelState.IsValid)
            {
                this._dbContext.Developers.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValuesCity();
                return View();
            }
        }



        [Authorize]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Developers.FirstOrDefault(c => c.ID == id);
            this.FillDropdownValuesCity();
            return View(model);
        }


        [Authorize]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var game = this._dbContext.Developers.Single(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(game);


            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownValuesCity();
            return View();
        }


        /*
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var dev = this._dbContext.Developers.Find(id);
            this._dbContext.Entry(dev).State = EntityState.Deleted;
                //= this._dbContext.Clients.FirstOrDefault(c => c.ID == id);
            //this._dbContext.Remove(client);
            this._dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }*/

        private void FillDropdownValuesCity()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.Cities)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCities = selectItems;
        }

    }
}