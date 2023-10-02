using StringCalculator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
