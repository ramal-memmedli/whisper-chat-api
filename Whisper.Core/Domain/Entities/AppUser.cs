using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Core.Domain.Models;

namespace Whisper.Core.Domain.Entities
{
    public class AppUser : IdentityUser, IEntity
    {
        public string PublicKey { get; set; } = string.Empty;
    }
}
