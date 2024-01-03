using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Core.Domain.Entities;
using Whisper.Data.Configurations;

namespace Whisper.Data.DbContext
{
    public class WhisperDbContext : IdentityDbContext<AppUser>
    {
        public WhisperDbContext(DbContextOptions<WhisperDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
