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
    public class BazniController : Controller
    {
        protected VideoGamesDbContext _dbContext;
        protected UserManager<AppUser> _userManager;
        public BazniController(VideoGamesDbContext dbContext, UserManager<AppUser> userManager)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
        }
        public String getUserId()
        {
            var userId = this._userManager.GetUserId(base.User);
            return userId;
        }
    }
}
