using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data
{
    public class ApplicationClaimsTypes
    {
        public static List<String> AppClaimTypes = new List<String>() {
            "Admin","MasterAdmin","User","VIP","Disabled","Banned"
        };
    }
}
