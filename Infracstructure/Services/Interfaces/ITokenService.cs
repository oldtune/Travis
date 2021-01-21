namespace Infracstructure.Services.Interfaces
{
    public interface ITokenService
    {
        string IssueToken();
        string IssueRefreshToken();
    }
}
