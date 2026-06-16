using Microsoft.AspNetCore.Identity;
using Snackis.Domain.Entities;

namespace Snackis.Presentation.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<MyUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<MyUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
