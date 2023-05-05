using MAF_Event_Center.Application.Queries.User;
using MAF_Event_Center.Domain.DTOs.AppUser;
using MAF_Event_Center.Domain.Entities;
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
    public class GetCurrentUserHanlder : IRequestHandler<GetCurrentUserQuery, AppUserDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetCurrentUserHanlder(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AppUserDTO> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var identityUserName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            var user =  await _userManager.Users.FirstOrDefaultAsync(x => x.Name == identityUserName);

            var result = new AppUserDTO()
            {
                Id = Guid.Parse(user.Id),
                Rank = user.Rank,
                UserName = user.UserName,
                CanCreate = user.CanCreate,
                Email = user.Email,
            };

            return result;

        }
    }
}
