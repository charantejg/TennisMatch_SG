namespace TennisMatch.Core.Interfaces
{
    public interface IPlayerSet
    {
        IPlayer Player { get; set; }
        byte Score { get; set; }

        byte TieBreakerScore { get; set; }
      
    }
}