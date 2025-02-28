using DevFreela.Core.Entities;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IAuthService _authservice;

        public CreateUserCommandHandler(DevFreelaDbContext dbContext, IAuthService authservice)
        {
            _dbContext = dbContext;
            _authservice = authservice;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authservice.ComputeSha256Hash(request.Password);
            
            var newUser = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);
            
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser.Id;
        }
    }
}
