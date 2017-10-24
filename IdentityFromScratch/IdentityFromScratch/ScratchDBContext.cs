using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFromScratch
{
    public class ScratchDBContext : IdentityDbContext<IdentityUser>
    {
        public ScratchDBContext():base("IdentityFromScratch")
        {
           
        }
    }
}