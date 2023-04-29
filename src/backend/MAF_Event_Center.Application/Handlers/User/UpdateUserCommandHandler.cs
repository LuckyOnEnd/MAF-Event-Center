using MAF_Event_Center.Application.Command.User;
using MAF_Event_Center.Domain.DTOs.AppUser;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleMaganer;

        public UpdateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleMaganer = roleManager;
        }
        public async Task<UpdateUserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id.ToString());

            // var userExist = await _userManager.FindByNameAsync(request.userName);
            if (user == null)
            {
                throw new ArgumentException("User with this username already exist");
            }

            var oldRole = await _userManager.GetRolesAsync(user);
            var role = await _roleMaganer.Roles.FirstOrDefaultAsync(x => x.Name == oldRole[0]);


            user.Name = request.userName;
            user.UserName = request.userName;
            user.Password = request.password;
            user.Rank = request.rank;

            if(request.canCreate != "string")
            {
                user.CanCreate = request.canCreate;
            }

            await _userManager.RemoveFromRoleAsync(user, role.Name);
            await _userManager.AddToRoleAsync(user, request.role);

            await _userManager.UpdateAsync(user);

            return default;
        }
    }
}
