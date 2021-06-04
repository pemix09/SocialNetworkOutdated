using SocialNetwork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace SocialNetwork.Data.DAL
{
    public class Role
    {
        private SocialNetworkContext _context;
        private readonly UserManager<AppUser> _userManager;
        public Role(SocialNetworkContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<bool> HasSpecificRoleAsync(string userID, string role)
        {
            AppUser AppUser = _context.Users.FirstOrDefault(m => m.Id == userID);
            if(AppUser == null)
            {
                return false;
            }
            return await _userManager.IsInRoleAsync(AppUser, role);
            
            /*
            IList<string> roles = await _userManager.GetRolesAsync(AppUser);
            foreach (var role in roles)
            {
                if(role.CompareTo(thing) == 0)
                {
                    return true;//user ma daną rolę
                }
            }
            return false;*/
               
        }


    }
}
