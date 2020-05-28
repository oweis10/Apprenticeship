using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apprenticeship.Data;
using Apprenticeship.Models;
using Microsoft.AspNetCore.Identity;

namespace Apprenticeship.Repositories
{
    public class FriendlyUser : IFriendlyUser
    {

        private ApplicationDbContext _dataContext;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public FriendlyUser(ApplicationDbContext dataContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public User GetUser(string id)
        {
            var user = _dataContext.Users.Where(x => x.Id == id).SingleOrDefault();
            
            return user;
        }
    }
}
