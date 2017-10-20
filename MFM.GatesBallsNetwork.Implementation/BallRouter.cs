using MFM.GatesBallsNetwork.Contracts;
using DryIoc;
using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Implementation
{
    public class BallRouter : IBallRouter
    {
        public async Task<char> RouteBallToContainer(IRootIntersection intersection)
        {
            return await RouteBall(intersection);
        }

        async Task<char> RouteBall(IRootIntersection intersection)
        {
            var _gate = intersection.LeftNode as IIntersection;
            if (_gate != null && _gate.IsOpen) //Gate not Container and Left is Open
            {
                _gate.IsOpen = false;
                ((IIntersection)intersection.RightNode).IsOpen = true;
                return await RouteBall(_gate);
            }
            else if (_gate != null && !_gate.IsOpen) //Gate not Container and Right is Open
            {
                _gate.IsOpen = true;
                ((IIntersection)intersection.RightNode).IsOpen = false;
                return await RouteBall(intersection.RightNode as IRootIntersection);
            }
            else
            {
                var _container = intersection.LeftNode as IBallContainer;
                if (_container.IsOpen)
                {
                    _container.IsFull = true;
                    _container.IsOpen = false;
                    (intersection.RightNode as IOpenable).IsOpen = true;
                    return _container.Id;
                }
                else
                {
                    _container = intersection.RightNode as IBallContainer;
                    _container.IsFull = true;
                    _container.IsOpen = false;
                    (intersection.LeftNode as IOpenable).IsOpen = true;
                    return _container.Id;
                }
            }
        }
    }
}
