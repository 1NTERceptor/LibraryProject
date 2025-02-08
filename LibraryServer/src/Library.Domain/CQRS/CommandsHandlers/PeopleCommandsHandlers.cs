using Library.Domain.CQRS.Commands;
using Library.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CommandsHandlers
{
    public class PeopleCommandsHandlers :
        IRequestHandler<CreateGuestCommand, bool>,
        IRequestHandler<CreateBorrowBook, bool>
    {
        private readonly IPeople _people;
        private readonly ILibrary _library;

        public PeopleCommandsHandlers(IPeople persons, ILibrary library)
        {
            _people = persons;
            _library = library;
        }

        public async Task<bool> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            await _people.CreateGuest(request.FirstName, request.LastName, request.GuestCardNumber);

            return true;
        }

        public async Task<bool> Handle(CreateBorrowBook request, CancellationToken cancellationToken)
        {
            var bookBorrowed = await _library.GuestBorrowBook(request.BookId, request.GuestId);

            if (bookBorrowed == null)
                return false;

            var result = await _people.BoorowBook(bookBorrowed, request.GuestId);

            return result;
        }
    }
}
