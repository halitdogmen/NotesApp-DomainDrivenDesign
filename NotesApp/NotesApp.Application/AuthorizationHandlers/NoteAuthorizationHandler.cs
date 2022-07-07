using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NotesApp.Domain.Aggregates.AccountAggregate.Concrete;
using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.AuthorizationHandlers
{
    public class NoteAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Note>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Note resource)
        {
            //If the account is a standaruser, it can only read/write its own notes.
            var authStatus = false;
            var role = context.User.FindFirst(ClaimTypes.Role)?.Value;
            if (role is not null)
            {
                if (role.Equals(nameof(StandartUser)))
                {
                    var id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (id is not null)
                    {
                        if (resource.AccountId.ToString().Equals(id))
                            authStatus = true;
                    }
                    else if (role.Equals(nameof(Admin)))
                    {
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
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
