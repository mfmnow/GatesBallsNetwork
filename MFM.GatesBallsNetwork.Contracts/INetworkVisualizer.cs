using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Contracts
{
    public interface INetworkVisualizer
    {
        Task<string> GetNetworkDiagram(int depth, IRootIntersection rootIntersection);
    }
}
