namespace MFM.GatesBallsNetwork.Contracts
{
    public interface IBallContainer: INode, IOpenable
    {
        bool IsFull { get; set; }        
        char Id { get; set; }
    }
}
