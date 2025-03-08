namespace Library.Domain.Models
{
    public class WorkerModel : ModelBase
    {
        public string EmployeeCardNumber { get; set; }

        public WorkerModel() { }

        public WorkerModel(int id, string login, string firstName, string lastName, string city, string employeeCardNumber) 
            : base(id, login, firstName, lastName, city)
        {
            EmployeeCardNumber = employeeCardNumber;
        }
    }
}
