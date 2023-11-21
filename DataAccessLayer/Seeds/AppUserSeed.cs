using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeds
{
    internal class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var adminUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@example.com" // E-posta eklemeyi unutma
            };

            
            builder.HasData(new AppUser { Id = Guid.NewGuid().ToString(), UserName = "Admin" ,PasswordHash = "Admin"});
        }
    }
}