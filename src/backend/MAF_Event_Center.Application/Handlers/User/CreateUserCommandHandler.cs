using MAF_Event_Center.Application.Command.User;
using MAF_Event_Center.Domain.DTOs.AppUser;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByNameAsync(request.userName);
            if(userExist != null)
            {
                throw new ArgumentException("User already exist");
            }

            AppUser user = new()
            {
                Email = request.email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.userName,
                Rank = request.rank,
                Name = request.userName,
            };

            var createUserResult = await _userManager.CreateAsync(user, request.password);
            if(!createUserResult.Succeeded)
            {
                
            }

            if (!await _roleManager.RoleExistsAsync(request.role))
                await _roleManager.CreateAsync(new IdentityRole(request.role));

            if(await _roleManager.RoleExistsAsync(request.role))
                await _userManager.AddToRoleAsync(user, request.role);

            return default;

        }
    }
}
