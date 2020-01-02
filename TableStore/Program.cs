using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositoty = new BaseFramework<Employee>("UseDevelopmentStorage=true", "Employee");
            repositoty.AddEntity(new Employee { Address = "Bradford", Name = "Pramod", PartitionKey = "emp", RowKey = "pramod@gmail.com" });
            
            var entities = repositoty.GetAll();
        }
    }
}
