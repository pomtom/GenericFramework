using Microsoft.Azure.Cosmos.Table;
using System;

namespace TableStore
{
    public class Employee : TableEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public Employee()
        {
        }

        public Employee(string PartitionKey, string RowKey)
        {
            this.PartitionKey = PartitionKey;
            this.RowKey = RowKey;
        }
    }
}
