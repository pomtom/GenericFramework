using Generic.Database.Poco;
using Generic.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Generic.Database.Repository
{
    public class EmployeeRepository : BaseRepository<GenericDbContext, Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployee()
        {
            var query = GetAll().ToList();
            return query;
        }

        public void InsertEmployeeUsingSP(Employee emp)
        {
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[]
                   {
                    new SqlParameter { ParameterName = "@Name",  Value =emp.Name , Direction = System.Data.ParameterDirection.Input},
                    new SqlParameter { ParameterName = "@Email",  Value =emp.Email, Direction = System.Data.ParameterDirection.Input },
                    new SqlParameter { ParameterName = "@Dob",  Value =emp.DOB, Direction = System.Data.ParameterDirection.Input },
                    new SqlParameter { ParameterName = "@adress",  Value = emp.Address, Direction = System.Data.ParameterDirection.Input }
                   };

                this.Context.Database.ExecuteSqlCommand("USP_InsertEmploee @Name, @Email, @Dob, @adress", sqlParams);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = FindByFunc(a => a.Id == id).FirstOrDefault();
            return employee;
        }

        public void UpdateEmployee(Employee emp)
        {
            EditEntity(emp);
            SaveEntity();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            DeleteEntity(employee);
            SaveEntity();
        }
    }
}
