namespace MFM.GatesBallsNetwork.Contracts
{
    public interface INetworkBuilder
    {
        IRootIntersection BuildNetwork(int depth);
    }
}
