using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    interface IIsAllowedToSeeThings
    {
        bool IsAllowedAsync(string thing, string userID);
    }
}
