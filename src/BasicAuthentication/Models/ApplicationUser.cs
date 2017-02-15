using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Post> Posts { get; set; }
        public virtual List<Answer> Answers { get; set; }
        
        public string GetUserId()
        {
            return this.Id;
        }
    }
}
