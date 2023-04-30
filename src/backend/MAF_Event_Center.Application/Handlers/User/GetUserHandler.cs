using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Application.Queries.User;
using MAF_Event_Center.Application.Services.Interfaces;
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
    public class GetUserHandler : IRequestHandler<GetUserByNameQuery, AppUserDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUserDTO> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);

            var userDto = new AppUserDTO()
            {
                UserName = user.UserName,
                Id = Guid.Parse(user.Id),
                Rank = user.Rank
            };

            return userDto;
        }
    }
}
