using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Core.Domain.Entities;

namespace Whisper.Core.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(AppUser user);
    }
}
