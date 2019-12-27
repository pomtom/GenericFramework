namespace Generic.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserService userservice;
        public UserService(IUserService _userservice)
        {
            this.userservice = _userservice;
        }

        public bool Login(string username, string pasword)
        {
            return userservice.Login(username, pasword);
        }
    }
}
