using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Snackis.Domain.Entities;

namespace Snackis.Application.Services
{
    public class AdminService
    {
        private readonly UserManager<MyUser> _userManager;
        public AdminService(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> IsAdminAsync(ClaimsPrincipal user)
        {
            var appUser = await _userManager.GetUserAsync(user);
            return appUser?.IsAdmin == true;
        }
    }
}
