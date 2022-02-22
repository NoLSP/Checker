using TaskChecker.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskChecker.Helpers
{
    public static class UsersHelper
    {
        public static string Role(this ClaimsPrincipal user)
        {
            return user.Claims.First(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
        }
    }
}
