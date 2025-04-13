using MediatR;

namespace Application.CQRS.Commands.Persons
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GuestCardNumber { get; set; }
        public string Login { get; set; }

        public CreateUserCommand(string firstName, string lastName, string guestCardNumber, string login)
        {
            FirstName = firstName;
            LastName = lastName;
            GuestCardNumber = guestCardNumber;
            Login = login;
        }
    }
}
