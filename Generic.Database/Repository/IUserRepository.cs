namespace Generic.Database.Repository
{
    public interface IUserRepository
    {
        bool Login(string username, string password);
    }
}
