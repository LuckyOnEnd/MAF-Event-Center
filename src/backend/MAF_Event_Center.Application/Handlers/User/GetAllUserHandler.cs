using MAF_Event_Center.Application.Queries.User;
using MAF_Event_Center.Domain.DTOs.AppUser;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.User
{
    public class GetAllUserHandler : IRequestHandler<GetAllUsersQuery, List<AppUserManager>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<AppUserManager>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();

            List<AppUserManager> result = new List<AppUserManager>();
            foreach(var x in users)
            {
                result.Add(new AppUserManager()
                {
                    CanCreate = x.CanCreate,
                    Email = x.Email,
                    Id = Guid.Parse(x.Id),
                    Name = x.Name,
                    Rank = x.Rank,
                });
            }
            return result;
        }
    }
}
