using MFM.GatesBallsNetwork.Contracts;

namespace MFM.GatesBallsNetwork.Implementation
{
    public class Intersection : IIntersection
    {
        public bool IsOpen { get; set; }
        public INode LeftNode { get; set; }
        public INode RightNode { get; set; }
    }
}
