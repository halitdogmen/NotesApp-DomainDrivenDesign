using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.AuthorizationHandlers
{
    public class AccountAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Account>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Account resource)
        {
            // ToDo: Implement Authorization rules
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
