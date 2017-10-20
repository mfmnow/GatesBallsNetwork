using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Contracts
{
    public interface INetworkNavigator
    {
        Task<List<char>> GetEmptyBallContainers(IRootIntersection rootIntersection);
    }
}
