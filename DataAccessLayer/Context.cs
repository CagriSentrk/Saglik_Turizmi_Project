using DataAccessLayer.Seeds;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context:IdentityDbContext<AppUser>
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            ////optionsBuilder.UseSqlServer("server=CSENTURK\\SQLSERVER;database=SaglikProjeDB;integrated security=true");
            //Data Source = DESKTOP - 7L6FK77; Initial Catalog = SaglikProjeDB; Integrated Security = True

            optionsBuilder.UseSqlServer("Server= DESKTOP-7L6FK77;Database=SaglikProjeDB4;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserSeed());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
} 
