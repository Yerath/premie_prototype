namespace AuthenticatieService.Interfaces
{
    public interface ITokenValidator
    {
        bool ValidateToken(string token);
    }
}
