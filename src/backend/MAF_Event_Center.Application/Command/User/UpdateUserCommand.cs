using MAF_Event_Center.Domain.DTOs.AppUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Command.User
{
    public record UpdateUserCommand(Guid id, string userName, string rank, string canCreate)
        : IRequest<UpdateUserDTO>
    {

    }
}
