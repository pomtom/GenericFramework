using System.Collections.Generic;

namespace TableStore
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeMethod();
        }
        public static void EmployeeMethod()
        {
            // Definition of where our tablestore is
            string TableName = "Employee";

            // Instanciate or TableStorage class
            TableStorage t = new TableStorage(TableName);

            // Create an object that inherits from TableEntity to be inserted into our table
            string partitionKey = "Contract";
            string rowKey = "deepak@gmail.com";

            Employee emp1 = new Employee("Contract", "pramod@gmail.com");
            emp1.Address = "Bradford";
            emp1.BirthDate = new System.DateTime();
            emp1.Name = "Pramod";

            Employee emp2 = new Employee("Contract", "sachin@gmail.com") { Name = "sachin", Address = "Sangola", BirthDate = new System.DateTime() };
            Employee emp3 = new Employee("Contract", "deepak@gmail.com") { Name = "deepak", Address = "Mumbai", BirthDate = new System.DateTime() };
            Employee emp4 = new Employee("Permenent", "nana@gmail.com") { Name = "nana", Address = "Mumbai", BirthDate = new System.DateTime() };
            Employee emp5 = new Employee("Permenent", "jana@gmail.com") { Name = "Jana", Address = "Mumbai", BirthDate = new System.DateTime() };

            t.Insert<Employee>(emp1);
            t.Insert<Employee>(emp2);
            t.Insert<Employee>(emp3);
            t.Insert<Employee>(emp4);
            t.Insert<Employee>(emp5);


            // Check is we can read this data back
            Employee data2 = t.GetSingle<Employee>(partitionKey, rowKey);



            List<Employee> listTableFileItem = t.GetAll<Employee>(partitionKey);

            // Check if we can modify this data

            emp2.Address = "Lotewadi";
            t.Replace<Employee>(data2.PartitionKey, data2.RowKey, data2, true);
            emp3 = t.GetSingle<Employee>(partitionKey, rowKey);


            // Remove the data
            t.DeleteEntry<Employee>(partitionKey, rowKey, data2);

            // Remove the table
            t.DeleteTable();
        }
        public static void DomeDataMethod()
        {
            // Definition of where our tablestore is
            string TableName = "MyTable";

            // Instanciate or TableStorage class
            TableStorage t = new TableStorage(TableName);

            // Create an object that inherits from TableEntity to be inserted into our table
            string partitionKey = "partitionkey1";
            string rowKey = "rowkey1";

            SomeDataItem data = new SomeDataItem(partitionKey, rowKey);
            data.String1 = "test.txt";
            data.String2 = "contents";

            t.Insert<SomeDataItem>(data);

            // Check is we can read this data back
            SomeDataItem data2 = t.GetSingle<SomeDataItem>(partitionKey, rowKey);



            List<SomeDataItem> listTableFileItem = t.GetAll<SomeDataItem>(partitionKey);


            // Check if we can modify this data

            data2.String2 = "NewContents";
            t.Replace<SomeDataItem>(data2.PartitionKey, data2.RowKey, data2, true);
            data = t.GetSingle<SomeDataItem>(partitionKey, rowKey);



            // Remove the data
            t.DeleteEntry<SomeDataItem>(partitionKey, rowKey, data2);

            // Remove the table
            t.DeleteTable();
        }

    }
}
