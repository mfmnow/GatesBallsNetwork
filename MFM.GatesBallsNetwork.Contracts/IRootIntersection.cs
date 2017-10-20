namespace MFM.GatesBallsNetwork.Contracts
{
    public interface IRootIntersection : INode
    {
        INode LeftNode { get; set; }
        INode RightNode { get; set; }
    }
}
