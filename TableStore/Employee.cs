using Microsoft.Azure.Cosmos.Table;
using System;

namespace TableStore
{
    public class Employee : TableEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public Employee()
        {
        }

        public Employee(string emptype, string email)
        {
            this.PartitionKey = emptype;
            this.RowKey = email;
            this.ETag = new Guid().ToString();
        }
    }
}
