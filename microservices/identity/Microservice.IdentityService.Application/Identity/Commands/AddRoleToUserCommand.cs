﻿using MassTransit;
using Microservice.Core;
using Microservice.CQRS;

namespace Microservice.IdentityService.Identity;

public class AddUserToRoleCommand : Command
{
    public Guid UserId { get; protected set; }

    public string RoleName { get; protected set; }

    public AddUserToRoleCommand(Guid userId, string roleName)
    {
        ArgumentNullException.ThrowIfNull(userId, nameof(userId));
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        UserId = userId;
        RoleName = roleName;
    }

    public class AddRoleToUserCommandHandler : ICommandHandler<AddUserToRoleCommand>
    {
        private readonly IUserManager _userManager;

        public AddRoleToUserCommandHandler(IUserManager userManager)
        {
            ArgumentNullException.ThrowIfNull(userManager, nameof(userManager));

            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<AddUserToRoleCommand> context)
        {
            User? user = await _userManager.FindByIdAsync(context.Message.UserId, context.CancellationToken);
            if (user is null)
            {
                throw new EntityNotFoundException(typeof(User), context.Message.UserId);
            }

            var result = await _userManager.AddToRoleAsync(user, context.Message.RoleName, context.CancellationToken);
            result.CheckErrors();
        }
    }
}