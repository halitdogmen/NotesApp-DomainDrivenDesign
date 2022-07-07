using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using NotesApp.Domain.Aggregates.AccountAggregate.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.AuthorizationHandlers
{
    public class AccountAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Account>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Account resource)
        {
            // If the account is a standaruser, it can only read/write its own information.
            bool authStatus = false;
            var role = context.User.FindFirst(ClaimTypes.Role)?.Value;
            if(role is not null)
            {
                if (role.Equals(nameof(StandartUser)))
                {
                    var id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if(id is not null)
                    {
                        if(resource.Id.ToString().Equals(id))
                            authStatus = true;
                    }
                }
            }
            if (authStatus)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            else
            {
                context.Fail();
                return Task.CompletedTask;
            }
            
        }
    }
}
