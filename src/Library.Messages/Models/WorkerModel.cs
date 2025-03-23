namespace Library.Messages.Models
{
    public class WorkerModel : PersonModelBase
    {
        public string EmployeeCardNumber { get; set; }

        public WorkerModel() { }

        public WorkerModel(Guid id, string login, string firstName, string lastName, string city, string employeeCardNumber) 
            : base(id, login, firstName, lastName, city)
        {
            EmployeeCardNumber = employeeCardNumber;
        }
    }
}
