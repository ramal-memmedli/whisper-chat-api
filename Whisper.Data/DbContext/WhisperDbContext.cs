using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Core.Domain.Entities;

namespace Whisper.Data.DbContext
{
    public class WhisperDbContext : IdentityDbContext<AppUser>
    {
        public WhisperDbContext(DbContextOptions<WhisperDbContext> options) : base(options) { }
    }
}
