using MAF_Event_Center.Domain.DTOs.AppUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Command.User
{
    public record CreateUserCommand(string userName, string rank, string email, string password, string role): IRequest<CreateUserDTO>
    {
    }
}
