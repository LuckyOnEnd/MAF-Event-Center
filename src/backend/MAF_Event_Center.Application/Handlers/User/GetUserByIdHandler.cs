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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, AppUserDTO>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUserByIdHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());

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
