using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ecommerceproject.Models;

namespace ecommerceproject.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {

    }
        
        public DbSet<ecommerceproject.Models.Malzeme> Malzeme { get; set; }
        public DbSet<ecommerceproject.Models.MalzemeImage> MalzemeImages { get; set; }


        public DbSet<ecommerceproject.Models.Category> Category { get; set; }
        
        public DbSet<ecommerceproject.Models.Comment> Comment { get; set; }


       
        
        
     
    

}
}
