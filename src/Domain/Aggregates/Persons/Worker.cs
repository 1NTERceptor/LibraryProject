﻿using Domain.Events.Worker;

namespace Domain.Aggregates.Persons
{
    public class Worker : Person
    {
        public string EmployeeCardNumber { get; protected set; }

        public static Worker CreateWorker(string firstName, string lastName, string employeeCardNumber, string login)
        {
            return new Worker(firstName, lastName, employeeCardNumber, login);
        }

        public Worker() { }

        private Worker(string firstName, string lastName, string employeeCardNumber, string login) : base(firstName, lastName, login)
        {
            EmployeeCardNumber = employeeCardNumber;
            AddDomainEvent(new WorkerCreated(Key, firstName, lastName));
        }
    }
}
