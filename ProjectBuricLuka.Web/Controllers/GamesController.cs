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
    public class GamesController : BazniController
    {
        
        public GamesController(VideoGamesDbContext dbContext, UserManager<AppUser> userManager) : base(dbContext, userManager)
        {
        }

     
        [AllowAnonymous]
        public ActionResult Index(GamesFilterModel filter)
        {
            filter ??= new GamesFilterModel();

            var gamesQuery = this._dbContext.VideoGames.Include(p=>p.Publisher).Include(d=>d.Developer).AsQueryable();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.Name))
                gamesQuery = gamesQuery.Where(g => (g.Name).ToLower().Contains(filter.Name.ToLower()));
                //clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Publisher))
                gamesQuery = gamesQuery.Where(g=>g.PublisherID != null && g.Publisher.Name.ToLower().Contains(filter.Publisher.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Genre))
                gamesQuery = gamesQuery.Where(g => g.Genre.ToLower().Contains(filter.Genre.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Developer))
                gamesQuery = gamesQuery.Where(g => g.DeveloperID != null && g.Developer.Name.ToLower().Contains(filter.Developer.ToLower()));

            var model = gamesQuery.ToList();
            return View("Index", model);
        }

        [AllowAnonymous]
        public IActionResult Details(int? id = null)
        {
            var game = this._dbContext.VideoGames
                .Include(p => p.Publisher)
                .Include(d => d.Developer)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(game);
        }



        [Authorize]
        public IActionResult Create()
        {
            this.FillDropdownValuesPublisher();
            this.FillDropdownValuesDeveloper();
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(VideoGame model)
        {
            if (ModelState.IsValid)
            {
                this._dbContext.VideoGames.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValuesPublisher();
                this.FillDropdownValuesDeveloper();
                return View();
            }
        }


        [Authorize]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.VideoGames.FirstOrDefault(c => c.ID == id);
            this.FillDropdownValuesPublisher();
            this.FillDropdownValuesDeveloper();
            return View(model);
        }


        [Authorize]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var game = this._dbContext.VideoGames.Single(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(game);


            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownValuesPublisher();
            this.FillDropdownValuesDeveloper();
            return View();
        }

        private void FillDropdownValuesPublisher()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.Publishers)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossiblePublishers = selectItems;
        }

        private void FillDropdownValuesDeveloper()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.Developers)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleDevelopers = selectItems;
        }

    }
}