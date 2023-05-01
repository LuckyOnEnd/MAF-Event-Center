using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Queries.User
{
    public class GetUserRoleQuery : IRequest<UserRoleResult>
    {
        

    }
}
