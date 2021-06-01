﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.UsersInfo
{
    public class IndexModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public IndexModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public IList<UserInfo> UserInfo { get;set; }

        public async Task OnGetAsync()
        {
            UserInfo = await _context.Users.ToListAsync();
        }
    }
}