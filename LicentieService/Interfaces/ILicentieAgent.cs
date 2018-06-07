namespace LicentieService.Interfaces
{
    internal interface ILicentieAgent
    {
        string RetrieveToken(string username, string password);
    }
}
