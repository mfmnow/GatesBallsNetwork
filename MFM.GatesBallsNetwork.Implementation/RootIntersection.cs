using MFM.GatesBallsNetwork.Contracts;

namespace MFM.GatesBallsNetwork.Implementation
{
    class RootIntersection : IRootIntersection
    {
        public INode LeftNode { get; set; }
        public INode RightNode { get; set; }
    }
}
