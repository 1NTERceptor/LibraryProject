using Application.CQRS.Commands.Persons;
using Library.Domain.Aggregates;
using Library.Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.CommandsHandlers
{
    public class PeopleCommandsHandlers :
        IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public PeopleCommandsHandlers(IUserRepository peopleRepository)
        {
            _userRepository = peopleRepository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userRepository.AddAsync(User.CreateUser(request.FirstName, request.LastName, request.GuestCardNumber, request.Login));
                await _userRepository.Commit();
            }
            catch(Exception ex)
            {
                throw new Exception($"Błąd przy dodawaniu nowego użytkownika o CardNamber:${request.GuestCardNumber}", ex);
            }

            return true;
        }
    }
}
