namespace Application.interfaces
{
    public interface IAuthenticationRepository
    {
        string GetOTP(string nationalCode);
        string GetToken();
    }
}
