using MediatR;

namespace Library.Domain.CQRS.Commands
{
    public class CreateGuestCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GuestCardNumber { get; set; }

        public CreateGuestCommand(string firstName, string lastName, string guestCardNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            GuestCardNumber = guestCardNumber;
        }
    }
}
