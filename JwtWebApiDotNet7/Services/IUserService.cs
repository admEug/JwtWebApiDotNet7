namespace JwtWebApiDotNet7.Services
{
    public interface IUserService
    {
        string GetMyName();
        List<string> GetMyRoles();
    }
}
