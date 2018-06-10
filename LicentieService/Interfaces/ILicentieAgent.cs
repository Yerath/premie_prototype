namespace LicentieService.Interfaces
{
    public interface ILicentieAgent
    {
        string RetrieveToken(string username, string password);
    }
}
