using MFM.GatesBallsNetwork.Contracts;

namespace MFM.GatesBallsNetwork.Implementation
{
    public class BallContainer : IBallContainer
    {
        public bool IsFull { get; set; }
        public bool IsOpen { get; set; }
        public char Id { get; set; }
    }
}
