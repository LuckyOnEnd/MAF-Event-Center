using MAF_Event_Center.Application.Queries.User;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.User
{
    public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, UserRoleResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetUserRoleHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }
        public async Task<UserRoleResult> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Name == userName);
                if(user == null)
                {
                    return new UserRoleResult() { Role = "NotFound" };
                }
                var userRole = await _userManager.GetRolesAsync(user);


                return new UserRoleResult() { Role = userRole[0] };
            }
            catch (Exception ex)
            {
                return new UserRoleResult() { Role = "NotFound" };
            }
        }
    }
}
