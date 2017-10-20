using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Contracts
{
    public interface IBallRouter
    {
        Task<char> RouteBallToContainer(IRootIntersection intersection);
    }
}
