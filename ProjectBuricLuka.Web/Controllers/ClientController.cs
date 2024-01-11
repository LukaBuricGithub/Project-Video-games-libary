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
    public class ClientController : BazniController
    {
        public ClientController(VideoGamesDbContext dbContext, UserManager<AppUser> userManager) : base(dbContext, userManager)
        {
        }


        /*
        [AllowAnonymous]
        public ActionResult Index(ClientFilterModel filter)
        {
            filter ??= new ClientFilterModel();

            var clientQuery = this._dbContext.Clients.Include(p => p.City).AsQueryable();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.CityID != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));

            var model = clientQuery.ToList();
            return View("Index", model);
        }

        [AllowAnonymous]
        public IActionResult Details(int? id = null)
        {
            var client = this._dbContext.Clients
                .Include(p => p.City)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(client);
        }

        [Authorize]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(Client model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedById=getUserId();
                this._dbContext.Clients.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValues();
                return View();
            }
        }


        [Authorize]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Clients.FirstOrDefault(c => c.ID == id);
            this.FillDropdownValues();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var client = this._dbContext.Clients.Single(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(client);
           

            if (ok && this.ModelState.IsValid)
            {
                client.UpdatedById=getUserId();
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownValues();
            return View();
        }

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.Cities)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCities = selectItems;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var client = this._dbContext.Clients.FirstOrDefault(c => c.ID == id);
            this._dbContext.Remove(client);
            this._dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        /*
        [HttpPost]
        public IActionResult IndexAjax(ClientFilterModel filter)
        {
            filter ??= new ClientFilterModel();

            var clientQuery = this._dbContext.Clients.Include(p => p.City).AsQueryable();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.CityID != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));

            var model = clientQuery.ToList();
            return View("Index", model);
        }*/
    }
}
