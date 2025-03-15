using Library.Domain.Aggregates;
using Library.Domain.Repository;
using Library.Messages.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CommandsHandlers
{
    public class PeopleCommandsHandlers :
        IRequestHandler<CreateGuestCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public PeopleCommandsHandlers(IPersonRepository peopleRepository)
        {
            _personRepository = peopleRepository;
        }

        public async Task<bool> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _personRepository.AddAsync(User.CreateUser(request.FirstName, request.LastName, request.GuestCardNumber, null));
            }
            catch(Exception ex)
            {
                throw new Exception($"Błąd przy dodawaniu nowego użytkownika o CardNamber:${request.GuestCardNumber}", ex);
            }

            return true;
        }
    }
}
