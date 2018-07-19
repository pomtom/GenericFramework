using Generic.Database.Poco;

namespace Generic.Business.Service
{
    public interface IEmployeeService
    {
        string GetAllEmployee();

        void InsertEmployeeUsingSP(string emp);
    }
}
