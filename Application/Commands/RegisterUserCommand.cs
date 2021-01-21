namespace Application.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
