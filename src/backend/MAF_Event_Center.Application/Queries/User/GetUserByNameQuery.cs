using MAF_Event_Center.Domain.DTOs.AppUser;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Queries.User
{
    public class GetUserByNameQuery : IRequest<AppUserDTO>
    {
        public string Username { get; set; }
    }
}
