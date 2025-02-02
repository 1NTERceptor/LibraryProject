using Library.Domain.CQRS.Events.Person;

namespace Library.Domain.Aggregates
{
    public class Worker : Person
    {
        public string EmployeeCardNumber { get; private set; }

        public static Worker CreateWorker(string firstName, string lastName, string employeeCardNumber, string login)
        {
            return new Worker(firstName, lastName, employeeCardNumber, login);
        }

        private Worker(string firstName, string lastName, string employeeCardNumber, string login) : base(firstName, lastName, login)
        {
            EmployeeCardNumber = employeeCardNumber;
            AddDomainEvent(new WorkerCreated(Id, firstName, lastName));
        }
    }
}
