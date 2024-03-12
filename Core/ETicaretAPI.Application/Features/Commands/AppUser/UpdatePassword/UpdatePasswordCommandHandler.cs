using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Exceptions;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeFailedException("Password and Password Confirm must be same !!!");

            await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
            return new();
        }
    }

}
