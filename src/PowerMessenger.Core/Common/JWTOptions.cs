using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMessenger.Core.Common
{
    public class JWTOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }

        public string? Secret { get; set; }
        public int TokenLifeTime { get; set; }
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret!));
        }
    }
}
