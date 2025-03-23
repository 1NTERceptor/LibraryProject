using MediatR;

namespace Library.Messages.Commands.Persons
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GuestCardNumber { get; set; }

        public CreateUserCommand(string firstName, string lastName, string guestCardNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            GuestCardNumber = guestCardNumber;
        }
    }
}
