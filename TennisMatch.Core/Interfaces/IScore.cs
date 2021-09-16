namespace TennisMatch.Core.Interfaces
{
    public interface IScore
    {
        int PointValue { get; }
        string ToString();
    }
}