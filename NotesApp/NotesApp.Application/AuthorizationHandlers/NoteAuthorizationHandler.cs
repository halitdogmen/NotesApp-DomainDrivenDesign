﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.AuthorizationHandlers
{
    public class NoteAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Note>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Note resource)
        {
            // ToDo: Implement Authorization rules
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
